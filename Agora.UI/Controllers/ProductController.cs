using Agora.BLL.Interfaces;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
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
           // List<string> ImageUrlList = LocalUpload(Product.Pictures);
          //  _repoProduct.AddProduct(Product, ImageUrlList);
            return RedirectToAction("MyProducts");
        }
        //Return cloudinary image path list
        [System.Obsolete]
        public List<string> LocalUpload(List<ProductPicture> ImageList)
        {

            List<string> ClooudinaryUrlList = new List<string>();

            string path = Path.Combine(Environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (ProductPicture postedFile in ImageList)
            {
                string fileName = Path.GetFileName(postedFile.Image.FileName);
                FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
                using (stream)
                {
                    postedFile.Image.CopyTo(stream);

                }

                WebRequest aa = System.Net.WebRequest.Create(stream.Name);
                string ClodinaryPath = CloudinaryUploadImage(aa.RequestUri.AbsolutePath);
                ClooudinaryUrlList.Add(ClodinaryPath);
                RemoveLocalFile(aa.RequestUri.AbsolutePath);

            }
            return ClooudinaryUrlList;
        }
        public void RemoveLocalFile(string FilePath)
        {
            FileInfo fi = new FileInfo(FilePath);
            fi.Delete();
        }
        public string CloudinaryUploadImage(string filename)
        {
            Account account = new Account(_configuration["Cloudinary:CloudName"], _configuration["Cloudinary:APIKey"], _configuration["Cloudinary:APISecret"]);
            Cloudinary cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(filename)
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            return uploadResult.SecureUrl.AbsoluteUri;
        }

        public JsonResult SubCategoriList(string CategoryId)
        {
            var subCategoryList = _repoCategory.SubCategoryList(Convert.ToInt32(CategoryId));
            return Json(subCategoryList);
        }
    }
}
