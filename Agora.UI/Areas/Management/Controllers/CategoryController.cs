using Agora.BLL.Interfaces;
using Agora.MODEL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Agora.UI.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize]
    public class CategoryController : Controller
    {
        ICategoryRepository _repoCategory;
        public CategoryController(ICategoryRepository repoCategory)
        {
            _repoCategory=repoCategory;
        }
        public IActionResult CategoryList()
        {
            List<Category> categories = _repoCategory.GetAllCategory();
            return View((categories, new Category()));
        }

        public IActionResult Delete(int id)
        {
            _repoCategory.DeleteCategory(id);
            return RedirectToAction("CategoryList");

        }

        [HttpPost]
        public IActionResult CreateCategory([Bind(Prefix = "Item2")] Category category)
        {
            _repoCategory.AddCategory(category);
            return RedirectToAction("CategoryList");

        }

        public JsonResult SubCategoriList(string CategoryId)
        {
            var subCategoryList= _repoCategory.SubCategoryList(Convert.ToInt32( CategoryId));
            return Json(subCategoryList);   
        }

    }
}
