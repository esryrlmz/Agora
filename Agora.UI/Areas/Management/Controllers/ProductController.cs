using Agora.BLL.Interfaces;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agora.UI.Areas.Management.Controllers
{
    [Area("Management")]
    public class ProductController : Controller
    {
        IProductRepository _repoProduct;
        ICategoryRepository _repoCategory;
        IUserRepository _repoUser;
        public ProductController(IProductRepository repoProduct,ICategoryRepository repoCategory,IUserRepository repoUser)
        {
            _repoProduct = repoProduct; 
            _repoCategory = repoCategory;
            _repoUser = repoUser;   
        }
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
            List<OnlyUser> userlist = _repoUser.OnlyUserList();
            return View(( new ProductDto(), _repoCategory.GetAllCategory(), userlist));
            
        }
        [HttpPost]
        public IActionResult Create([Bind(Prefix = "Item1")] ProductDto Product)
        {
            // ürün db ekleme işlemini yap,
            // önce ürünün kendisini ekle
            // sub categori id alanı nul ise ana kategori, değilse alt kategoriye eklenecek(ara tabloya ürünid ve categoriıd leri insert et)
            // urun eklendiyse o ürüne ait resimleri ekle(Cloudinary)
            return RedirectToAction("ProductList");
        }
        public IActionResult Edit()
        {

            return View(new Product());
        }

        public IActionResult Delete()
        {

            return RedirectToAction("ProductList");
        }


    }
}
