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
    public class CreateProductModel : PageModel
    {
        
        public SelectList ProductCategories;
        private readonly IProductCategoryApplication categoryApplication;
        private readonly IProductApplication productApplication;
        public CreateProductModel(IProductApplication productApplication,IProductCategoryApplication categoryApplication)
        {
            this.productApplication = productApplication;
            this.categoryApplication = categoryApplication;
        }
        public void OnGet()
        {
            ProductCategories = new SelectList(categoryApplication.GetAll(),"Id","Name");
        }
        public RedirectToPageResult OnPost(CreateProduct command)
        {
            productApplication.Creat(command);
            return RedirectToPage("/Product/ProductIndex");
        }
    }
}
