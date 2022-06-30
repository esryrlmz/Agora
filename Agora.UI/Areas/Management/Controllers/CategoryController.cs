using Agora.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agora.UI.Areas.Management.Controllers
{
    [Area("Management")]
    public class CategoryController : Controller
    {
        public IActionResult CategoryList()
        {
            List<Category> categories = new List<Category>();   
            return View(categories);
        }
        public IActionResult Create()
        {
            return View(new Category());
        }
    }
}
