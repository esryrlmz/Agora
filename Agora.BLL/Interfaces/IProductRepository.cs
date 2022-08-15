using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Agora.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.BLL.Interfaces
{
    public  interface IProductRepository:IRepository<Product>
    {

        void AddProduct(ProductDto Product, List<String> ImageUrlList);
        List<Product> ProductList();
        List<ProductPicture> GetProductImages(int id);

        Product GetFullProduct(int id);
        Category GetProductCategory(int id);
        void updateProductCategory(int productID, int CategoryID);
        void UpdateProductPicture(ProductPicture picture);
        void updateProduct(Product product);
        void updateProductStatus(int id, ProductStatus ps);
        List<ProductCard> ProductCardListCategory(int CategoryID);
        List<ProductCard> ProductCardList();
        List<ProductCard> MyProductCardList(int UserId);
        List<ProductCard> FilterProductCardList(FilterDto filter);
    }
}
