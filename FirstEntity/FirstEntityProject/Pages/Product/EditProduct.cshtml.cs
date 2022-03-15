using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfFirstLibrary.ProductCategory;
using EfFirstLibrary.TheProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstEntityProject.Pages.Product
{
    public class EditProductModel : PageModel
    {
        public EditProduct command;
        public SelectList productcategories;
        private readonly IProductApplication productApplication;
        private readonly IProductCategoryApplication productCategoryApplication;
        public EditProductModel(IProductApplication productApplication,IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
            this.productApplication = productApplication;
        }
        public void OnGet(int Id)
        {
            command = productApplication.GetDetails(Id);
            productcategories =new SelectList( productCategoryApplication.GetAll(),"Id","Name");
        }
        public RedirectToPageResult OnPost(EditProduct command)
        {
            productApplication.Edit(command);
            return RedirectToPage("/Product/ProductIndex");
        }
    }
}
