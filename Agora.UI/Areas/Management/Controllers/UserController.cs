using Microsoft.AspNetCore.Mvc;
using Agora.MODEL.Entities;
using System.Collections.Generic;

namespace Agora.UI.Areas.Management.Controllers
{
    [Area("Management")]
    public class UserController : Controller
    {
       
        public IActionResult UserList()
        {
            //userdto ile user ve userdetail tablosunu kullan
            List<User> users = new List<User>();    
            return View(users);
        }
        public IActionResult NewUser()
        {
            return View(new User());
        }
        public IActionResult AdminList()
        {
            List<User> users = new List<User>();
            return View(users);
        }
        public IActionResult NewAdmin()
        {
            return View(new User());
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
