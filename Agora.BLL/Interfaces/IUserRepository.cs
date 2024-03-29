﻿using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Agora.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.BLL.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        UserDto AddUserDto(UserDto item);

        List<User> UserList(Role role);
        User GetUser(int userId);
        UserDetail GetUserDetail(int userId);
        void UpdateUser(User user);
        Task<int> UpdateUserDetail(UserDetail userdetail);
        List<OnlyUser> OnlyUserList();
        User UserProfile(int id);
        User UserProfile(string email);
        List<Product> TakeProductsUser(int id);
        List<Product> SendProductsUser(int id);
        User IsUserLogin(string UsernameOrMail);
    }
}
