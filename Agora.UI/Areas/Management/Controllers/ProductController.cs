using Agora.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Agora.UI.Areas.Management.Controllers
{
    [Area("Management")]
    public class ProductController : Controller
    {
        public IActionResult ProductList()
        {
            return View();
        }

        public IActionResult Create()
        {
            
            return View(new Product());
        }
    }
}
