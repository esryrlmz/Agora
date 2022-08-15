using Agora.BLL.Interfaces;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Agora.UI.Helper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Agora.UI.Controllers
{
    public class ProductController : Controller
    {
        ICategoryRepository _repoCategory; 
        IProductRepository _repoProduct;
        IConfiguration _configuration;
        [System.Obsolete]
        private IHostingEnvironment Environment;

        [Obsolete]
        public ProductController(ICategoryRepository repoCategory, IProductRepository repoProduct,
            IConfiguration configuration, IHostingEnvironment environment)
        {
            _repoCategory = repoCategory;   
            _repoProduct = repoProduct;
            _configuration = configuration;
            Environment = environment;
        }
        public IActionResult ProductList(int? id)
        {
            // if eğer id var ise kategori kapsamında productları listele
           // eger id yok ise tüm product ları listele
            return View();
        }

        [HttpPost]
        public IActionResult ProductList(FilterDto filter)
        {
            return View();
        }
        public IActionResult MyProducts()
        {
            return View();
        }
        public IActionResult ViewProduct()
        {
            return View();
        }

        [Authorize(Policy = "UserPolicy")]
        public IActionResult NewProduct()
        {
            return View((new ProductDto(), _repoCategory.GetAllCategory()));
        }
        [HttpPost]
        [Obsolete]
        public IActionResult Create([Bind(Prefix = "Item1")] ProductDto Product)
        {
            if (Product.SubCategoryID != 0)
            {
                Product.CategoryID = Product.SubCategoryID;
            }

            // Product.UserID=oturum açan kişinin IDSİ
            // CloudinaryImage cimage = new CloudinaryImage(_configuration,Environment);
            // List<string> ImageUrlList = cimage.LocalUpload(Product.Pictures);
            //  _repoProduct.AddProduct(Product, ImageUrlList);
            return RedirectToAction("MyProducts");
        }

        public JsonResult SubCategoriList(string CategoryId)
        {
            var subCategoryList = _repoCategory.SubCategoryList(Convert.ToInt32(CategoryId));
            return Json(subCategoryList);
        }
    }
}
