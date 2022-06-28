using Microsoft.AspNetCore.Mvc;

namespace Agora.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
