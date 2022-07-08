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

namespace Agora.UI.Areas.Management.Controllers
{
    [Area("Management")]
    public class ProductController : Controller
    {
        IProductRepository _repoProduct;
        ICategoryRepository _repoCategory;
        IUserRepository _repoUser;
        IConfiguration _configuration;
        [System.Obsolete]
        private IHostingEnvironment Environment;

        [System.Obsolete]
        public ProductController(IProductRepository repoProduct,
            ICategoryRepository repoCategory,IUserRepository repoUser,
            IConfiguration configuration, IHostingEnvironment environment)
        {
            _repoProduct = repoProduct;
            _repoCategory = repoCategory;
            _repoUser = repoUser;
            _configuration = configuration;
            Environment = environment;
        }
        public IActionResult ProductList()
        {
            return View(_repoProduct.ProductList());
        }

        public IActionResult Product(int id)
        {
            Product product = _repoProduct.GetFullProduct(id);
            List<ProductPicture> productPictures = _repoProduct.GetProductImages(id);
            return View((product, productPictures));
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
            if (Product.SubCategoryID!=0)
            {
                Product.CategoryID = Product.SubCategoryID;
            }
            List<string> ImageUrlList = LocalUpload(Product.Pictures);
            _repoProduct.AddProduct(Product, ImageUrlList);
            return RedirectToAction("ProductList");
        }
       
        
        
        
        
        public IActionResult Edit(int id)
        {

            return View(new Product());
        }

        public IActionResult Delete(int id)
        {

            return RedirectToAction("ProductList");
        }






        //Return cloudinary image path list
        [System.Obsolete]
        public List<string> LocalUpload(List<ProductPicture> ImageList)
        {
            string wwwPath = Environment.WebRootPath;
            string contentPath = Environment.ContentRootPath;
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
        public string CloudinaryUploadImage( string filename)
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

    }
}
