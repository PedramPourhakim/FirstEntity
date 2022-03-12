using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfFirstLibrary.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstEntityProject.Pages.Category
{
    public class CreateCategoryModel : PageModel
    {
        public CreateCategory command;
        private readonly IProductCategoryApplication productCategoryApplication;
        public CreateCategoryModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }
        public void OnGet()
        {
        }
        public RedirectToPageResult OnPost(CreateCategory command)
        {
            productCategoryApplication.Create(command);
            return RedirectToPage("/Category/CategoryIndex");
        }
    }
}
