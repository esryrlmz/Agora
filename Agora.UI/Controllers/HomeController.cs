using Agora.BLL.Interfaces;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
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
        public HomeController(IRepository<Town> repoTown, IRepository<City> repoCity, ICategoryRepository repoCategory)
        {
            _repoTown = repoTown;
            _repoCity = repoCity;
            _repoCategory = repoCategory;
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

    }
}
