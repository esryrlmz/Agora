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
        IRepository<City> _repoCity;
        ICategoryRepository _repoCategory;
        IRepository<UserDetail> _repoUserDetail;
        public HomeController(IRepository<Town> repoTown, IRepository<City> repoCity, ICategoryRepository repoCategory, IRepository<UserDetail> repoUserDetail)
        {
            _repoTown = repoTown;
            _repoCity = repoCity;
            _repoCategory = repoCategory;
            _repoUserDetail = repoUserDetail;
        }
        public IActionResult Index()
        {
            ViewBag.CityList = _repoCity.GetActives();
            ViewBag.CategoryList = _repoCategory.GetAllCategory();
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

        public JsonResult PasswordForget( string mail)
        {
           
            UserDetail user = _repoUserDetail.GetByFilter(x => x.Email == mail)[0];
           if (mail!=null&& user != null)
            {
                string passwordKod= new Random().Next(10000, 99999).ToString();
                MailDto dtomail = new MailDto();
                dtomail.mail = mail;
                dtomail.subject = "Pazaryeri Kullanıcı Sifre İsteği";
                dtomail.text = " Merhaba " + user.NameSurname + "    Pazaryeri şifre sıfırlama Kodunuz: " + passwordKod;
                bool durum = new SendMail().Contact(dtomail);
                if(durum)
                {
                   
                    TempData["PasswordKod"] = passwordKod;
                    TempData["CssClassName"] = "success";
                    TempData["Message"] = "Lutfen 2 dk içinde mailize gelen kod ile şifrenizi değiştiriniz";
                    //return RedirectToAction("ResetPassword","User", new { email = mail });
                    return Json(new
                    {
                        islem = "300",
                        CssClassName = TempData["CssClassName"],
                        Message = TempData["Message"],
                        Email = mail,
                        Url = "User/ResetPassword"
                    });
                }

                else
                {
                    TempData["CssClassName"] = "Error";
                    TempData["Message"] = "Mail Gönderilemedi Lütfen Yeniden Deneyiniz";
                    //return RedirectToAction("Login", "Auth");
                    return Json(new
                    {
                        islem = "100",
                        CssClassName = TempData["CssClassName"],
                        Message = TempData["Message"],
                        Url = "Auth/LogIn"
                    });
                }
               
            }
           else
            {
                TempData["CssClassName"] = "Error";
                TempData["Message"] = "Mail Adresiniz Sistemimizde Bulunmuyor, Lütfen Üye Olunuz";
                //return RedirectToAction("Login", "Auth");
                return Json(new
                {
                    islem = "200",
                    CssClassName = TempData["CssClassName"],
                    Message = TempData["Message"],
                    Url = "Auth/LogIn"
                });
            }

           
        }

    }
}
