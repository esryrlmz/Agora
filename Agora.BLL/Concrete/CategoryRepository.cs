using Agora.BLL.Base;
using Agora.BLL.Interfaces;
using Agora.DAL.Context;
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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        MyDbContext _db;
        public CategoryRepository(MyDbContext db) : base(db)
        {
            _db = db;
        }
        public List<Category> GetAllCategory()
        {
            List<Category> Categories = _db.Categories.Where(x => x.Status != DataStatus.Deleted&& x.CategoryID==null).
                Include(x=>x.Childs.Where(x => x.Status != DataStatus.Deleted)).ToList();
            return Categories;
        }

        public void DeleteCategory(int id)
        { 
            Delete(id);
        }

        public void AddCategory(Category category)
        {
            Add(category);
        }
        public List<Category> SubCategoryList(int id)
        {
            return _db.Categories.Where(x => x.Status != DataStatus.Deleted && x.CategoryID == id).ToList();
        }

        public bool HasProductForCategory(int id)
        {
            int productCount = _db.ProductCategories.Where(x => x.CategoryID == id)
               .Include(z => z.Product).ToList().Count();
            return productCount != 0 ? true : false;        
        }
    }
}
