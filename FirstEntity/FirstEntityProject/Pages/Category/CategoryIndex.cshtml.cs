using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfFirstLibrary.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstEntityProject.Pages.Category
{
    public class CategoryIndexModel : PageModel
    {
        public List<CategoryViewModel> productcategories { get; set; }
        private readonly IProductCategoryApplication productCategoryApplication;
        public CategoryIndexModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }
        public void OnGet(string name)
        {
            productcategories = productCategoryApplication.Search(name);
        }
    }
}
