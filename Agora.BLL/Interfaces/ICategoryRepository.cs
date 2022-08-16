using Agora.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.BLL.Interfaces
{
    public interface ICategoryRepository: IRepository<Category>
    {    
        List<Category> GetAllCategory();

        void DeleteCategory(int id);
        void AddCategory(Category category);
        List<Category> SubCategoryList(int id);
        bool HasProductForCategory(int id);
    }
}
