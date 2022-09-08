using Agora.BLL.Interfaces;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Agora.MODEL.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Agora.UI.Controllers
{
    public class UserController : Controller
    {
        IRepository<City> _repoCity;
        IRepository<Town> _repoTown;
        IUserRepository _repoUser;



        public UserController(IRepository<City> repoCity, IRepository<Town> repoTown, IUserRepository repoUser)
        {
            _repoCity = repoCity;   
            _repoTown = repoTown;
            _repoUser = repoUser;
        }

        
        public IActionResult SignUp()
        {
            List<City> CityList = _repoCity.GetActives();
            UserDto userdto = new UserDto() { Role = Role.Uye };
            return View((userdto, CityList));
        }
        public JsonResult LoadTownlist(string cityId)
        {
            var TownList = _repoTown.GetByFilter(x => x.CityID == Convert.ToInt32(cityId));
            return Json(TownList);
        }
        [HttpPost]
        public IActionResult SignUp([Bind(Prefix = "Item1")] UserDto userDto)
        {
            List<City> CityList = _repoCity.GetActives();
            if (!ModelState.IsValid)
            {
                return View((userDto, CityList));
            }
            userDto.Role = Role.Uye;
            UserDto userdto = _repoUser.AddUserDto(userDto);
            if (userdto.StatusMessage != null)
            {
                ViewBag.CssClassName = "danger";
                ViewBag.Message = userdto.StatusMessage;
                return View((userDto, CityList));
            }
            else
            {
                TempData["CssClassName"] = "success";
                TempData["Message"] = "Kaydınız alınmıştır, Lütfen Giriş yapınız!";
                return RedirectToAction("LogIn", "Auth");
            }
        }
        public IActionResult ResetPassword(string email)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.CssClassName = TempData["CssClassName"];
                ViewBag.Message = TempData["Message"];
            }
            CPassword cp = new CPassword();
            cp.Mail = email;
            return View(cp); 
        }

        [HttpPost]
        public IActionResult ChangePassword(CPassword cp)
        {
            if (TempData["PasswordKod"]!=null&& cp.MailKod== TempData["PasswordKod"].ToString()&&cp.NewPassword!=null)
            {
                User usr = _repoUser.UserProfile(cp.Mail);
                usr.Password = BCrypt.Net.BCrypt.HashPassword(cp.NewPassword);
                _repoUser.Update(usr);
                TempData["CssClassName"] = "success";
                TempData["Message"] = "Şifreniz Başarıyla Sıfırlandı Lütfen Giriş Yapınız!";
            }
            else
            {
                TempData["CssClassName"] = "Danger";
                TempData["Message"] = "Lütfen Yeniden Deneyin!";
            }
            return RedirectToAction("LogIn", "Auth");
        }

    }
}
