using Agora.MODEL.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Agora.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.City = 0;
            ViewBag.Town = 0;
            ViewBag.UstKategoriID = 0;
            ViewBag.AltKategoriID = 0;
            return View( );
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
