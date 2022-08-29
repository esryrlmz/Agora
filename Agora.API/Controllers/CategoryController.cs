using Agora.BLL.Interfaces;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Agora.API.Controllers
{
    [Route("api/v1/categories")]
    [ApiController]
    public class CategoryController : Controller
    {
        IProductRepository _repoProduct;
        ICategoryRepository _repoCategory;
        public CategoryController(IProductRepository repoProduct, ICategoryRepository  repoCategory)
        {
            _repoProduct = repoProduct;
            _repoCategory = repoCategory;
        }
        //kategoriye ait yayınlanan ürünler
        [HttpGet("{category_id}/products")]
        public IEnumerable<ProductCard> CategoryProductList(string category_id)
        {
            return _repoProduct.ProductCardListCategory(Convert.ToInt32(category_id)).ToArray();
        }

        //ana kategoriden seçilen kategorinin alt kategorileri
        [HttpGet("/subcategories")]
        public IEnumerable<Category> SubCategory(string category_id)
        {
            return _repoCategory.SubCategoryList(Convert.ToInt32(category_id)).ToArray();
        }

        //ana kategori
        [HttpGet]
        public IEnumerable<Category> CategoryList()
        {
            return _repoCategory.GetAllCategory();
        }
    }
}
