using Microsoft.AspNetCore.Mvc;
using Agora.MODEL.Entities;
using System.Collections.Generic;
using Agora.BLL.Interfaces;
using Agora.MODEL.Dto;
using System;
using Agora.MODEL.Enums;

namespace Agora.UI.Areas.Management.Controllers
{
    [Area("Management")]
    public class UserController : Controller
    {

        IRepository<City> _repoCity;
        IRepository<Town> _repoTown;
        IUserRepository _repoUser;
        IRepository<UserDetail> _repodetail;
        public UserController(IRepository<City> repoCity, IRepository<Town> repoTown, IUserRepository repoUser, IRepository<UserDetail> repodetail)
        {
            _repoCity = repoCity;
            _repoTown=repoTown;
            _repoUser=repoUser; 
            _repodetail=repodetail;   
        }
      
        public IActionResult NewUser()
        {
            List<City> CityList = _repoCity.GetActives();
            UserDto userdto = new UserDto() { Role = Role.Uye };
            return View((userdto, CityList));
        }
        public IActionResult NewAdmin()
        {
            List<City> CityList = _repoCity.GetActives();
            UserDto userdto = new UserDto() { Role = Role.Admin };
            return View((userdto, CityList));
        }

        public JsonResult LoadTownlist(string cityId)
        {
            var TownList = _repoTown.GetByFilter(x => x.CityID == Convert.ToInt32(cityId));
            return Json(TownList);
        }

        [HttpPost]
        public IActionResult NewUser([Bind(Prefix="Item1")] UserDto userDto)
        {
           
            List<City> CityList = _repoCity.GetActives();
            if (!ModelState.IsValid)
            {
                return View((userDto, CityList));
            }
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
                TempData["Message"] = "Üye Kaydı Başarıyla Tamamlanmıştır";
                return RedirectToAction("UserList","User");
            }
        }
        [HttpPost]
        public IActionResult NewAdmin([Bind(Prefix = "Item1")] UserDto userDto)
        {
            List<City> CityList = _repoCity.GetActives();
            if (!ModelState.IsValid)
            {
                return View((userDto, CityList));
            }
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
                TempData["Message"] = "Admin Üye Kaydı Başarıyla Tamamlanmıştır";
                return RedirectToAction("AdminList", "User");
            }

        }

            //buraya parametre olarak verilen değişken xxx ise arayüzde asp-route-xxx olmalı!
            public IActionResult GetUser(int id)
        {
            User user = _repoUser.GetUser(id);
            UserDetail userdetail = _repoUser.GetUserDetail(id);
            return View((user, userdetail));
        }

        [HttpPost]
        public IActionResult UpdateUserDetail([Bind(Prefix = "Item2")] UserDetail userDetail)
        {
            _repodetail.Update(userDetail);
            return RedirectToAction("UserList");
        }
        [HttpPost]
        public IActionResult UpdateUser([Bind(Prefix = "Item1")] User user)
        {
            _repoUser.UpdateUser(user);
            return RedirectToAction("UserList");
        }
        public IActionResult AdminList()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.CssClassName = TempData["CssClassName"];
                ViewBag.Message = TempData["Message"];
            }
            List<User> users = _repoUser.UserList(Role.Admin);
            return View(users);
        }
        public IActionResult UserList()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.CssClassName = TempData["CssClassName"];
                ViewBag.Message = TempData["Message"];
            }
            List<User> users = _repoUser.UserList(Role.Uye);
            return View(users);
        }
        public IActionResult UserDelete(int id)
        {
            _repoUser.Delete(id);
            return RedirectToAction("UserList");
        }




        public IActionResult Profile()
        {
            User user = new User();     
            return View(user);
        }

        public IActionResult UserProfile(int id)
        {
            User user = _repoUser.UserProfile(id);
            List<Product> takeProducts = _repoUser.TakeProductsUser(id);
            List<Product> sendProducts = _repoUser.SendProductsUser(id);
            return View((user, takeProducts, sendProducts));
        }
        public IActionResult LogAuth()
        {
            return RedirectToAction("Index", "Home");
        }

        
    }
}
