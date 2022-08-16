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
        ICommentRepository _repoComment;
        IUserRepository _repoUser;
        [System.Obsolete]
        private IHostingEnvironment Environment;

        [Obsolete]
        public ProductController(ICategoryRepository repoCategory, IProductRepository repoProduct,
            IConfiguration configuration, IHostingEnvironment environment, ICommentRepository repoComment, IUserRepository repoUser)
        {
            _repoCategory = repoCategory;   
            _repoProduct = repoProduct;
            _repoComment = repoComment;
            _repoUser=repoUser;
            _configuration = configuration;
            Environment = environment;
            
        }
        public IActionResult ProductList(int? id)
        {
            List<ProductCard> ProductList;
            if (id!=null) {
                ProductList = _repoProduct.ProductCardListCategory(Convert.ToInt32(id));
            }else {
                ProductList = _repoProduct.ProductCardList();
            }
            return View(ProductList);
        }
        [HttpPost]
        public IActionResult FilterProductList( FilterDto filter)
        {
            List<ProductCard> ProductList = _repoProduct.FilterProductCardList(filter);
            return View(ProductList);
        }


        [Authorize(Policy = "UserPolicy")]
        public IActionResult MyProducts()
        {
            var luser = (System.Security.Claims.ClaimsIdentity)User.Identity;
            List<ProductCard> ProductList = _repoProduct.MyProductCardList(Convert.ToInt32(luser.FindFirst("UserID").Value));
            return View(ProductList);
        }
        public IActionResult ViewProduct(int id)
        {
            Product prd = _repoProduct.GetFullProduct(id);
            List<ProductPicture> picture = _repoProduct.GetProductImages(id);
            List<Comment> comments = _repoComment.ProductCommentsAsc(id);
            Comment newcomment = new Comment() { ProductID = id };
            return View((prd,picture,comments, newcomment));
        }
        [Authorize(Policy = "UserPolicy")]
        public IActionResult AddComment([Bind(Prefix = "Item4")]  Comment comment)
        {
            var luser = (System.Security.Claims.ClaimsIdentity)User.Identity;
            comment.NameSurname = luser.FindFirst("NameSurname").Value;
            _repoComment.Add(comment);
            TempData["CommentMessage"] = "Yorumunuz değerlendirildikten sonra yayınlanacaktır...";
            return RedirectToAction("ViewProduct" , new { id = comment.ProductID });
        }
        [Authorize(Policy = "UserPolicy")]
        public IActionResult NewProduct()
        {
            return View((new ProductDto(), _repoCategory.GetAllCategory()));
        }
        [HttpPost]
        [Obsolete]
        [Authorize(Policy = "UserPolicy")]
        public IActionResult Create([Bind(Prefix = "Item1")] ProductDto Product)
        {
            if (Product.SubCategoryID != 0)
            {
                Product.CategoryID = Product.SubCategoryID;
            }
            //oturum açan kişi

                  var luser = (System.Security.Claims.ClaimsIdentity)User.Identity;
                  Product.UserID = Convert.ToInt32(luser.FindFirst("UserID").Value);
                 CloudinaryImage cimage = new CloudinaryImage(_configuration,Environment);
                 List<string> ImageUrlList = cimage.LocalUpload(Product.Pictures);
                  _repoProduct.AddProduct(Product, ImageUrlList);
                return RedirectToAction("MyProducts");
        }

        public JsonResult SubCategoriList(string CategoryId)
        {
            var subCategoryList = _repoCategory.SubCategoryList(Convert.ToInt32(CategoryId));
            return Json(subCategoryList);
        }


        public IActionResult Edit(int id)
        {
            Product prd = _repoProduct.GetFullProduct(id);
            ProductDto productdto = new ProductDto();
            if (prd.ProductCategories[0].Category.CategoryID != null)
            { productdto.CategoryID = (int)prd.ProductCategories[0].Category.CategoryID; }
            else { productdto.CategoryID = prd.ProductCategories[0].Category.ID; }
            productdto.SubCategoryID = prd.ProductCategories[0].Category.ID;
            productdto.CategoryName = prd.ProductCategories[0].Category.CategoryName;
            productdto.ShortName = prd.ShortName;
            productdto.Description = prd.Description;
            productdto.IsActive = prd.IsActive;
            productdto.Pictures = _repoProduct.GetProductImages(id);
            productdto.ProductID = prd.ID;
            ViewBag.username = _repoUser.GetUserDetail(prd.UserID).NameSurname;
            return View((productdto, _repoCategory.GetAllCategory()));
        }
        [HttpPost]
        [System.Obsolete]
        public IActionResult Edit([Bind(Prefix = "Item1")] ProductDto editPrd)
        {

            // 1.Adımı: kategoriler değişmiş mi?
            if (editPrd.SubCategoryID == 0) // ANA KATEGORİYE GEÇTİYSE
            {
                _repoProduct.updateProductCategory(editPrd.ProductID, editPrd.CategoryID);
            }
            else // ALT KATEGORİYE GEÇTİYSE
            {
                _repoProduct.updateProductCategory(editPrd.ProductID, editPrd.SubCategoryID);
            }

            //2.adım: model verilerini güncelle
            _repoProduct.updateProduct(new Product()
            {
                ID = editPrd.ProductID,
                ShortName = editPrd.ShortName,
                Description = editPrd.Description,
                IsActive = editPrd.IsActive
            });

            //3.adım: modelin resimleri değişmişmi, değişeni cloudinary sisteminden kaldır
            //yeni resmi cloudinarye ekle ve oluşan url linkini db den güncelle
            foreach (ProductPicture picture in editPrd.Pictures)
            {
                List<ProductPicture> pictures = new List<ProductPicture>();
                if (picture.Image != null)
                {
                    CloudinaryImage cimage = new CloudinaryImage(_configuration, Environment);
                    cimage.CloudinaryDestroyImage(picture.PictureUrl);
                    pictures.Add(picture);
                    List<string> ImageUrl = cimage.LocalUpload(pictures);
                    picture.PictureUrl = ImageUrl[0];
                    _repoProduct.UpdateProductPicture(picture);
                }
            }

            return RedirectToAction("ViewProduct", new { id = editPrd.ProductID });
        }
    }
}
