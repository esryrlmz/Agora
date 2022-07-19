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
