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
            User user = _repoUser.UserProfile(product.UserID);
            List<ProductPicture> productPictures = _repoProduct.GetProductImages(id);
            return View((product, productPictures, user));
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
            List<string> ImageUrlList = LocalUpload(Product.Pictures);
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
                         CloudinaryDestroyImage(picture.PictureUrl);
                         pictures.Add(picture);
                         List<string> ImageUrl = LocalUpload(pictures);
                         picture.PictureUrl = ImageUrl[0];
                         _repoProduct.UpdateProductPicture(picture);
                     }
                }

            return RedirectToAction("ProductList");
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
        public string CloudinaryDestroyImage(string filename)
        {
            Account account = new Account(_configuration["Cloudinary:CloudName"], _configuration["Cloudinary:APIKey"], _configuration["Cloudinary:APISecret"]);
            Cloudinary cloudinary = new Cloudinary(account);
            string[] urlArray = filename.Split('/');
            string sonadim = urlArray[urlArray.Length - 1];
            string sonyrl = sonadim.Substring(0, sonadim.IndexOf("."));
            var deletionParams = new DeletionParams(sonyrl);
            var deletionResult = cloudinary.Destroy(deletionParams);
            return deletionResult.Result;
        }

    }
}
