using Microsoft.AspNetCore.Mvc;

namespace Agora.UI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult LogAuth()
        {
            return RedirectToAction("Index","Home");
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
