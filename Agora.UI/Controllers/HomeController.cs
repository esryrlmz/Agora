using Agora.BLL.Interfaces;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Agora.UI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Town> _repoTown;
        public HomeController(IRepository<Town> repoTown)
        {
            _repoTown = repoTown;
        }
        public IActionResult Index()
        {
            ViewBag.City = 0;
            ViewBag.Town = 0;
            ViewBag.UstKategoriID = 0;
            ViewBag.AltKategoriID = 0;
            return View( );
        }
        public JsonResult LoadTownlist(string cityId)
        {
            var TownList = _repoTown.GetByFilter(x => x.CityID == Convert.ToInt32(cityId));
            return Json(TownList);
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
