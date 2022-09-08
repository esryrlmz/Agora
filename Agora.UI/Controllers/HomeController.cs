using Agora.BLL.Interfaces;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Agora.UI.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Agora.UI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Town> _repoTown;
        ICategoryRepository _repoCategory;
        IRepository<UserDetail> _repoUserDetail;
        public HomeController(IRepository<Town> repoTown,  ICategoryRepository repoCategory, IRepository<UserDetail> repoUserDetail)
        {
            _repoTown = repoTown;
            _repoCategory = repoCategory;
            _repoUserDetail = repoUserDetail;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult LoadTownlist(string cityId)
        {
            var TownList = _repoTown.GetByFilter(x => x.CityID == Convert.ToInt32(cityId));
            return Json(TownList);
        }
        public JsonResult SubCategoriList(string CategoryId)
        {
            var subCategoryList = _repoCategory.SubCategoryList(Convert.ToInt32(CategoryId));
            return Json(subCategoryList);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult HowToGive()
        {
            return View();
        }
        public IActionResult HowToTake()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PasswordForget( [Bind(Prefix = "Item2")] MailDto email)
        {
           
            List<UserDetail> users = _repoUserDetail.GetByFilter(x => x.Email == email.mail);
           if (email.mail != null&& users.Count > 0)
            {
                UserDetail user = users[0];
                string passwordKod= new Random().Next(10000, 99999).ToString();
                MailDto dtomail = new MailDto();
                dtomail.mail = email.mail;
                dtomail.subject = "Pazaryeri Kullanıcı Sifre İsteği";
                dtomail.text = " Merhaba " + user.NameSurname + "    Pazaryeri şifre sıfırlama Kodunuz: " + passwordKod;
                bool durum = new SendMail().Contact(dtomail);
                if(durum)
                {
                   
                    TempData["PasswordKod"] = passwordKod;
                    TempData["CssClassName"] = "success";
                    TempData["Message"] = "Lutfen 2 dk içinde mailize gelen kod ile şifrenizi değiştiriniz";
                    return RedirectToAction("ResetPassword", "User", new { email = email.mail });
                }
                else
                {
                    TempData["CssClassName"] = "Danger";
                    TempData["Message"] = "Mail Gönderilemedi Lütfen Yeniden Deneyiniz";
                    return Redirect(Request.Headers["Referer"]);
                }
               
            }
           else
            {
                TempData["CssClassName"] = "Danger";
                TempData["Message"] = "Mail Adresiniz Sistemimizde Bulunmuyor, Lütfen Üye Olunuz";
                return Redirect(Request.Headers["Referer"]);
            }   
        }

    }
}
