using Agora.BLL.Base;
using Agora.BLL.Interfaces;
using Agora.DAL.Context;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Agora.MODEL.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agora.BLL.Concrete
{
    public class ProductRepository:Repository<Product>, IProductRepository
    {
        MyDbContext _db;
        public ProductRepository(MyDbContext db) : base(db)
        {
            _db = db;
        }
        public void AddProduct(ProductDto product, List<String> imageUrlList)
        {
            try
            {
                //Prodduct ekle
                UserDetail user = _db.UserDetails.Find(product.UserID);
                Product newproduct = new Product()
                {
                    UserID = product.UserID,
                    ShortName = product.ShortName,
                    Description = product.Description,
                    IsActive = product.IsActive,
                    Town = user.Towner,
                    City = user.Country
                };
                _db.Products.Add(newproduct);
                _db.SaveChanges();
                int product_id = newproduct.ID;
                // Product Category bağlantısnı yap
                _db.ProductCategories.Add(new ProductCategory() { ProductID = product_id, CategoryID = product.CategoryID });
                _db.SaveChanges();

                //Productın İmagelerini ekle
                foreach (string item in imageUrlList)
                {
                    _db.ProductPictures.Add(new ProductPicture() { ProductID = product_id, PictureUrl = item });
                    _db.SaveChanges();
                }
                //Kategori ekle
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex);
            }
           
          
        }

        public List<Product> ProductList()
        {
            return _db.Products.Where(x => x.Status != DataStatus.Deleted && x.IsActive == true).Include(x => x.User).ThenInclude(y=>y.UserDetail).ToList(); 
        }
     
        
        public List<ProductCard> ProductCardListCategory(int CategoryID,int? AuthUserID=null)
        {// kategoriye ait yayında olan ürünler
            List<ProductCard> plist = new List<ProductCard>();
            if (AuthUserID == null)
            {
               plist = _db.ProductCategories.Where(x => x.CategoryID == CategoryID)
               .Include(z => z.Product).ThenInclude(s => s.ProductPictures).Include(m => m.Product.Comments)
               .Where(z => z.Product.Status != DataStatus.Deleted && z.Product.IsActive == true && z.Product.ProductStatus == ProductStatus.Ownerless)
               .Select(a => new ProductCard
               {
                   image = a.Product.ProductPictures.First().PictureUrl,
                   CommentCount = a.Product.Comments.Where(x => x.IsCheck == true && x.Status != DataStatus.Deleted).Count(),
                   ProductName = a.Product.ShortName,
                   CreatedDate = a.Product.CreatedDate.ToString().Substring(1, 10),
                   ProductStatus = a.Product.ProductStatus,
                   ProductID = a.Product.ID
               }).ToList();
            }
            else
            {
                plist = _db.ProductCategories.Where(x => x.CategoryID == CategoryID)
              .Include(z => z.Product).ThenInclude(s => s.ProductPictures).Include(m => m.Product.Comments)
              .Where(z => z.Product.Status != DataStatus.Deleted && z.Product.IsActive == true && z.Product.ProductStatus == ProductStatus.Ownerless && z.Product.UserID != AuthUserID)
              .Select(a => new ProductCard
              {
                  image = a.Product.ProductPictures.First().PictureUrl,
                  CommentCount = a.Product.Comments.Where(x => x.IsCheck == true && x.Status != DataStatus.Deleted).Count(),
                  ProductName = a.Product.ShortName,
                  CreatedDate = a.Product.CreatedDate.ToString().Substring(1, 10),
                  ProductStatus = a.Product.ProductStatus,
                  ProductID = a.Product.ID
              }).ToList();
            }

            return plist;
        }
        public List<ProductCard> ProductCardList(int? AuthUserID = null)
        {
            List<ProductCard> plist = new List<ProductCard>();
            if (AuthUserID == null)
            {
                plist = _db.Products.Include(s => s.ProductPictures).Include(m => m.Comments)
                   .Where(z => z.Status != DataStatus.Deleted && z.IsActive == true && z.ProductStatus == ProductStatus.Ownerless)
                   .Select(a => new ProductCard
                   {
                       image = a.ProductPictures.First().PictureUrl,
                       CommentCount = a.Comments.Where(x => x.IsCheck == true && x.Status != DataStatus.Deleted).Count(),
                       ProductName = a.ShortName,
                       CreatedDate = a.CreatedDate.ToString().Substring(1, 10),
                       ProductStatus = a.ProductStatus,
                       ProductID = a.ID
                   }).ToList();
            }
            else
            {
               plist = _db.Products.Include(s => s.ProductPictures).Include(m => m.Comments)
                  .Where(z => z.Status != DataStatus.Deleted && z.IsActive == true && z.ProductStatus == ProductStatus.Ownerless && z.UserID != AuthUserID)
                  .Select(a => new ProductCard
                  {
                      image = a.ProductPictures.First().PictureUrl,
                      CommentCount = a.Comments.Where(x => x.IsCheck == true && x.Status != DataStatus.Deleted).Count(),
                      ProductName = a.ShortName,
                      CreatedDate = a.CreatedDate.ToString().Substring(1, 10),
                      ProductStatus = a.ProductStatus,
                      ProductID = a.ID
                  }).ToList();
            }
            return plist;
        }

        public List<ProductCard> FilterProductCardList(FilterDto filter, int? AuthUserID = null)
        {
            // seçilen filtrelere göre product listele
            List<ProductCard> pglist = new List<ProductCard>();
            var query = (_db.ProductCategories
                          .Include(z => z.Product).ThenInclude(s => s.ProductPictures).Include(m => m.Product.Comments)
                          .Where(z => z.Product.Status != DataStatus.Deleted && z.Product.IsActive == true && z.Product.ProductStatus == ProductStatus.Ownerless)
                         ).AsQueryable();

            if (filter.City != 0)
            {
                query = query.Where(x => x.Product.City == _db.Cities.Where(x => x.ID == filter.City).FirstOrDefault().CityName);
            }
            if (filter.Town != 0)
            {
                query = query.Where(x => x.Product.Town == _db.Towns.Where(x => x.ID == filter.Town).FirstOrDefault().TownName);
            }
            if (filter.UstKategoriID != 0)
            {
                if (filter.AltKategoriID != 0)
                {
                    filter.UstKategoriID = filter.AltKategoriID;
                    query = query.Where(x => x.CategoryID == filter.UstKategoriID);
                }
                else
                {

                    //üst kategorinin altındaki kategoırilere bağlı ürünler için önce alt kategori ürünlerini al sonra üst kategori ürünlerini al
                    List<int> result = _db.Categories.Where(x => x.CategoryID == filter.UstKategoriID).Select(a => a.ID).ToList();
                    result.Add(filter.UstKategoriID);
                    if (result.Count() > 0 && _db.ProductCategories.Where(p => result.Contains(p.CategoryID)).Count() > 0)
                    {
                        query = query.Where(p => result.Contains(p.CategoryID));
                    }

                }
            }
           
            if (AuthUserID != null)
            {
                query = query.Where(p => p.Product.UserID!=AuthUserID);
            }
            List<ProductCard> plist = query.Select(a => new ProductCard
            {
                image = a.Product.ProductPictures.First().PictureUrl,
                CommentCount = a.Product.Comments.Where(x => x.IsCheck == true && x.Status != DataStatus.Deleted).Count(),
                ProductName = a.Product.ShortName,
                CreatedDate = a.Product.CreatedDate.ToString().Substring(1, 10),
                ProductStatus = a.Product.ProductStatus,
                ProductID = a.Product.ID
            }).ToList();

            return plist;

        }






        public List<ProductCard> MyProductCardList(int UserId)
        {
            List<ProductCard> plist = _db.Products.Include(s => s.ProductPictures).Include(m => m.Comments)
               .Where(z => z.Status != DataStatus.Deleted && z.IsActive == true && z.UserID == UserId)
               .Select(a => new ProductCard
               {
                   image = a.ProductPictures.First().PictureUrl,
                   CommentCount = a.Comments.Where(x => x.IsCheck == true&& x.Status!=DataStatus.Deleted).Count(),
                   ProductName = a.ShortName,
                   CreatedDate = a.CreatedDate.ToString().Substring(1, 10),
                   ProductStatus = a.ProductStatus,
                   ProductID = a.ID
               }).ToList();
            return plist;
        }
        public List<ProductCard> ProductListCategory(int CategoryID)
        {// kategoriye ait yayında olan ürünler
            List<ProductCard> plist = _db.ProductCategories.Where(x => x.CategoryID == CategoryID)
               .Include(z => z.Product).ThenInclude(s => s.ProductPictures).Include(m => m.Product.Comments)
               .Where(z => z.Product.Status != DataStatus.Deleted && z.Product.IsActive == true && z.Product.ProductStatus == ProductStatus.Ownerless)
               .Select(a => new ProductCard
               {
                   image = a.Product.ProductPictures.First().PictureUrl,
                   CommentCount = a.Product.Comments.Where(x => x.IsCheck == true && x.Status != DataStatus.Deleted).Count(),
                   ProductName = a.Product.ShortName,
                   CreatedDate = a.Product.CreatedDate.ToString().Substring(1, 10),
                   ProductStatus = a.Product.ProductStatus,
                   ProductID = a.Product.ID
               }).ToList();


            return plist;
        }
   
        public Product GetFullProduct(int id)
        {
            Product product= _db.Products.Where(x => x.Status != DataStatus.Deleted && x.IsActive == true&& x.ID==id).FirstOrDefault();    
            product.ProductCategories = _db.ProductCategories.Where(z => z.ProductID == id).ToList();
            int CategoriID = _db.ProductCategories.Where(z => z.ProductID == id).FirstOrDefault().CategoryID;
            product.ProductCategories.First().Category= new Category()
            {
                ID = (int)_db.Categories.Where(z => z.ID == CategoriID).FirstOrDefault().ID,// ALT KATEGORİ
                CategoryID = (int?)_db.Categories.Where(z => z.ID == CategoriID).FirstOrDefault().CategoryID,//üst kategori
                CategoryName = _db.Categories.Where(z => z.ID == CategoriID).FirstOrDefault().CategoryName
            };
            return product;

        }
        public List<ProductPicture> GetProductImages(int id)
        {
            return _db.ProductPictures.Where(x => x.ProductID == id).ToList();

        }
        
        public Category GetProductCategory(int id)
        {
            int CategoriID = _db.ProductCategories.Where(z => z.ProductID == id).FirstOrDefault().CategoryID;
            return new Category()
            {
                ID = (int)_db.Categories.Where(z => z.ID == CategoriID).FirstOrDefault().ID,// ALT KATEGORİ
                CategoryID = (int?)_db.Categories.Where(z => z.ID == CategoriID).FirstOrDefault().CategoryID,//üst kategori
                CategoryName = _db.Categories.Where(z => z.ID == CategoriID).FirstOrDefault().CategoryName
            };
        }
        
        public void updateProductCategory(int productID, int CategoryID)
        {
            ProductCategory pc = _db.ProductCategories.Where(x => x.ProductID == productID).FirstOrDefault();
            if (pc.CategoryID!= CategoryID)
            {
                pc.CategoryID= CategoryID;
                _db.Update(pc);
                _db.SaveChanges();
            }
            
        }

        public void updateProduct(Product product)
        {
            Product prd = GetById(product.ID);
            prd.ShortName=product.ShortName;
            prd.Description=product.Description;
            prd.IsActive=product.IsActive;
            _db.Update(prd);
            _db.SaveChanges();

        }

        public void UpdateProductPicture(ProductPicture picture)
        {
            _db.Update(picture);
            _db.SaveChanges();
        }
        public void updateProductStatus(int id, ProductStatus ps)
        {
            Product prd = GetById(id);
            prd.ProductStatus = ps;
            Update(prd);
        }
    }
}
