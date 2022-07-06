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
        public IActionResult createUser([Bind(Prefix="Item1")] UserDto userDto)
        {
            _repoUser.AddUserDto(userDto);
            if(userDto.Role == Role.Admin) {
              return  RedirectToAction("AdminList"); }
            else{
                return RedirectToAction("UserList");}
            
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
            List<User> users = _repoUser.UserList(Role.Admin);
            return View(users);
        }
        public IActionResult UserList()
        {
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
        public IActionResult LogAuth()
        {
            return RedirectToAction("Index", "Home");
        }

        
    }
}
