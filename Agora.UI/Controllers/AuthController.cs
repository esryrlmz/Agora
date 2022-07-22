using Microsoft.AspNetCore.Mvc;

namespace Agora.UI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.CssClassName = TempData["CssClassName"];
                ViewBag.Message = TempData["Message"];
            }
            return View();
        }
        public IActionResult LogAuth()
        {
            return RedirectToAction("Index","Home");
        }
       
    }
}
