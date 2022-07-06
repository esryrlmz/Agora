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
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        MyDbContext _db;
        public ProductRepository(MyDbContext db) : base(db)
        {
            _db = db;
        }

        public void AddProduct(ProductDto Product)
        {
            
        }
    }
}
