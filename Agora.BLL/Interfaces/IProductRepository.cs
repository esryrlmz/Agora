using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
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
    }
}
