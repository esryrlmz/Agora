using Agora.BLL.Interfaces;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Agora.API.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductController : Controller
    {
        IProductRepository _repoProduct;
        ICommentRepository _repoComment;
        public ProductController(IProductRepository repoProduct, ICommentRepository repoComment)
        {
            _repoProduct = repoProduct;
            _repoComment = repoComment; 
        }

        [HttpGet]
        public IEnumerable<ProductCard> AllProductList()
        {
            return _repoProduct.ProductCardList().ToArray();
        }
 
        [HttpGet("{product_id}")]
        public string GetProduct(string product_id)
        {
            Product prd = _repoProduct.GetFullProduct(Convert.ToInt32(product_id));
            string json = JsonConvert.SerializeObject(prd, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [HttpGet("{product_id}/images")]
        public IEnumerable<ProductPicture> GetProductImages(string product_id)
        {
            return _repoProduct.GetProductImages(Convert.ToInt32(product_id)).ToArray();
        }
        [HttpGet("{product_id}/comment")]
        public IEnumerable<Comment> GetProductComment(string product_id)
        {
            return _repoComment.ProductCommentsAsc(Convert.ToInt32(product_id)).ToArray();
        }


    }
}
