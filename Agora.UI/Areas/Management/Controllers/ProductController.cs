using Agora.BLL.Interfaces;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net;
using Agora.UI.Helper;

namespace Agora.UI.Areas.Management.Controllers
{
    [Area("Management")]
    public class ProductController : Controller
    {
        IProductRepository _repoProduct;
        ICategoryRepository _repoCategory;
        IUserRepository _repoUser;
        IConfiguration _configuration;
        ICommentRepository _repoComment;
        [System.Obsolete]
        private IHostingEnvironment Environment;

        [System.Obsolete]
        public ProductController(IProductRepository repoProduct,
            ICategoryRepository repoCategory,IUserRepository repoUser,
            IConfiguration configuration, IHostingEnvironment environment,
            ICommentRepository repoComment)
        {
            _repoProduct = repoProduct;
            _repoCategory = repoCategory;
            _repoUser = repoUser;
            _configuration = configuration;
            _repoComment = repoComment;
            Environment = environment;
        }
        public IActionResult ProductList()
        {
            return View(_repoProduct.ProductList());
        }

        public IActionResult Product(int id)
        {
            Product product = _repoProduct.GetFullProduct(id);
            User user = _repoUser.UserProfile(product.UserID);
            List<ProductPicture> productPictures = _repoProduct.GetProductImages(id);
            List<Comment> commentlist = _repoComment.ProductComments(id);
            return View((product, productPictures, user, commentlist));
        }
        public IActionResult Create()
        {
            List<OnlyUser> userlist = _repoUser.OnlyUserList();
            return View(( new ProductDto(), _repoCategory.GetAllCategory(), userlist));
            
        }
        [HttpPost]
        [System.Obsolete]
        public IActionResult Create([Bind(Prefix = "Item1")] ProductDto Product)
        {
            // urun eklendiyse o ürüne ait resimleri ekle(Cloudinary)
            // TODO: sAYFA Bekletme eklenecek
            if (Product.SubCategoryID!=0)
            {
                Product.CategoryID = Product.SubCategoryID;
            }
            CloudinaryImage cimage = new CloudinaryImage();
            List<string> ImageUrlList = cimage.LocalUpload(Product.Pictures);
            _repoProduct.AddProduct(Product, ImageUrlList);
            return RedirectToAction("ProductList");
        }

        
        public IActionResult Edit(int id)
        {
             Product prd = _repoProduct.GetFullProduct(id);
             ProductDto productdto = new ProductDto();
             if (prd.ProductCategories[0].Category.CategoryID != null)
             { productdto.CategoryID = (int)prd.ProductCategories[0].Category.CategoryID; }
             else {  productdto.CategoryID = prd.ProductCategories[0].Category.ID; }
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
            if(editPrd.SubCategoryID==0) // ANA KATEGORİYE GEÇTİYSE
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
             } );

            //3.adım: modelin resimleri değişmişmi, değişeni cloudinary sisteminden kaldır
            //yeni resmi cloudinarye ekle ve oluşan url linkini db den güncelle
                foreach (ProductPicture picture in editPrd.Pictures)
                {
                     List < ProductPicture > pictures = new List<ProductPicture>();
                     if (picture.Image!=null)
                     {
                         CloudinaryImage cimage = new CloudinaryImage();
                         cimage.CloudinaryDestroyImage(picture.PictureUrl);
                         pictures.Add(picture);
                         List<string> ImageUrl = cimage.LocalUpload(pictures);
                         picture.PictureUrl = ImageUrl[0];
                         _repoProduct.UpdateProductPicture(picture);
                     }
                }

            return RedirectToAction("ProductList");
        }
       

    }
}
