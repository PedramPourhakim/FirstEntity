using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfFirstLibrary.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstEntityProject.Pages.Category
{
    public class EditModel : PageModel
    {
        public EditCategory command;
        private readonly IProductCategoryApplication productCategoryApplication;
        public EditModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }
        public void OnGet(int id)
        {
            command = productCategoryApplication.GetDetails(id);
        }
        public RedirectToPageResult OnPost(EditCategory command)
        {
            productCategoryApplication.Edit(command);
            return RedirectToPage("/Category/CategoryIndex");
        }
    }
}
