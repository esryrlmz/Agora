using Agora.BLL.Interfaces;
using Agora.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agora.UI.ViewComponents
{
    public class FilterMenu : ViewComponent
    {
        private readonly IRepository<City> _repoCity;
        private readonly ICategoryRepository _repoCategory;
        public FilterMenu(IRepository<City> repoCity, ICategoryRepository repoCategory)
        {
           _repoCategory = repoCategory;    
            _repoCity = repoCity;   
        }

        public IViewComponentResult Invoke()
        {
            List<City> CityList = _repoCity.GetActives();
            List<Category>  CategoryList = _repoCategory.GetAllCategory();
            return View((CityList,CategoryList));
        }

    }
}
