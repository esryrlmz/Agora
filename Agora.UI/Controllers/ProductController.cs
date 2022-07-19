using Microsoft.AspNetCore.Mvc;

namespace Agora.UI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult ProductList()
        {
            return View();
        }
    }
}
