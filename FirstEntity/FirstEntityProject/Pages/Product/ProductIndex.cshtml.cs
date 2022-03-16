using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfFirstLibrary.TheProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstEntityProject.Pages.Product
{
    public class ProductIndexModel : PageModel
    {
        public List<ProductViewModel> Products { get; set; }
        private readonly IProductRepository productRepository;
        private readonly IProductApplication productApplication;
        public ProductIndexModel(IProductApplication productApplication,IProductRepository productRepository)
        {
            this.productApplication = productApplication;
            this.productRepository = productRepository;
        }
        public void OnGet(ProductSearchModel productSearchModel)
        {
            Products = productApplication.Search(productSearchModel);
        }
        public RedirectToPageResult OnGetRemove(int Id)
        {
            productApplication.Remove(Id);
            return RedirectToPage("/Product/ProductIndex");
        }
        public RedirectToPageResult OnGetRestore(int Id)
        {
            productApplication.Restore(Id);
            return RedirectToPage("/Product/ProductIndex");
        }
    }
}
