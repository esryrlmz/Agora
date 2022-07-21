using Microsoft.AspNetCore.Mvc;

namespace Agora.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
