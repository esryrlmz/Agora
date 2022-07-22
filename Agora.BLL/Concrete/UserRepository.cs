using Agora.BLL.Base;
using Agora.BLL.Interfaces;
using Agora.DAL.Context;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Agora.MODEL.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.BLL.Concrete
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        MyDbContext _db;
        public UserRepository(MyDbContext db):base(db)
        {
            _db = db;
        }

        public bool AnyUserName(User user)
        {
            bool durum = false;
            if ( _db.Users.Where(x => x.UserName == user.UserName).FirstOrDefault() == null) { durum = false; } else { durum = true; };
            return durum;
        }
        public UserDto AddUserDto(UserDto item)
        {
            if (_db.UserDetails.Where(x => x.Email == item.Email).FirstOrDefault() != null)
            {
                item.StatusMessage = "Email Sistemimize Kayıtlıdır!";

            }
            else if (Any(x => x.UserName == item.UserName))
            {
                item.StatusMessage = "Kullanıcı Adı Sistemimize Kayıtlıdır!";
            }
            else
            {
                item.StatusMessage = null;
                User user = new User()
                {
                    UserName = item.UserName,
                    Password = BCrypt.Net.BCrypt.HashPassword(item.Password),
                    Role = item.Role
                };
                _db.Users.Add(user);
                _db.SaveChanges();
                int user_id = user.ID;
                UserDetail userDetail = new UserDetail()
                {
                    Gender = item.Gender,
                    NameSurname = item.NameSurname,
                    Phone = item.Phone,
                    Email = item.Email,
                    Country = _db.Cities.Find(Convert.ToInt32(item.Country)).CityName,
                    Towner = _db.Towns.Find(Convert.ToInt32(item.Towner)).TownName,
                    UserID = user_id
                };
                _db.UserDetails.Add(userDetail);
                _db.SaveChanges();
            }
            return item;

        }

        public List<User> UserList(Role role)
        {
            List<User> userList = _db.Users.Where(x => x.Status != DataStatus.Deleted&& x.Role==role)
                .Include(x => x.UserDetail).ToList();
            return userList;
        }
        public User GetUser(int userId)
        {
            return GetById(userId);
        }
        public UserDetail GetUserDetail(int userId)
        {
            UserDetail userdetail = _db.UserDetails.Where(x => x.Status != DataStatus.Deleted && x.UserID== userId).FirstOrDefault();
            return userdetail;
        }
        public void UpdateUser(User user)
        {
            User lastuser = GetUser(user.ID);
            if (lastuser!=null)
            {
                lastuser.UserName = user.UserName;
                lastuser.Role = user.Role;
                lastuser.Status = DataStatus.Updates;
                lastuser.ModifiedDate = DateTime.Now;
                if (user.Password != null)
                {
                    lastuser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                }
                _db.Update(lastuser);
                _db.SaveChanges();
            }
        }

        public List<OnlyUser> OnlyUserList()
        {
          return  _db.UserDetails
                .Where(x => x.Status != DataStatus.Deleted&& x.User.Role==Role.Uye)
                .Select(x => new OnlyUser
                {
                    NameSurname=x.NameSurname,
                    UserID=x.UserID
                }).ToList();
        }

        public User UserProfile(int id)
        {
           return _db.Users.Where(x => x.Status != DataStatus.Deleted&& x.ID==id).Include(x => x.UserDetail).FirstOrDefault();
        }

        public List<Product> TakeProductsUser(int id)
        {
            return _db.Products.Include(x=>x.Transfer).Where(x => x.Status != DataStatus.Deleted&& x.Transfer.UserID==id).OrderByDescending(y => y.CreatedDate).ToList();
        }
        public List<Product> SendProductsUser(int id)
        {
           return _db.Products.Where(x => x.Status != DataStatus.Deleted && x.UserID == id).OrderByDescending(y=>y.CreatedDate).ToList();
        }

        public User IsUserLogin( string UsernameOrMail)
        {
            return _db.Users.Include(x => x.UserDetail).
                Where(x => x.Status != DataStatus.Deleted&&(x.UserName== UsernameOrMail || x.UserDetail.Email== UsernameOrMail)).FirstOrDefault();

        }

    }
}
