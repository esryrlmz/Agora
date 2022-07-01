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

        public IActionResult Product()
        {

            return View(new Product());
        }
        public IActionResult Create()
        {
            
            return View(new Product());
        }
        public IActionResult Edit()
        {

            return View(new Product());
        }
    }
}
