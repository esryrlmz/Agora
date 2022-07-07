using Agora.BLL.Base;
using Agora.BLL.Interfaces;
using Agora.DAL.Context;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
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
    }
}
