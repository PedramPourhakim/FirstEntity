using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfFirstLibrary.ProductCategory
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository productCategoryRepository;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }
        public void Create(CreateCategory command)
        {
            if (productCategoryRepository.Exists(command.Name))
                return;
            var Category = new Category(command.Name);
            productCategoryRepository.Create(Category);
        }

        public void Edit(EditCategory command)
        {
            var productcategory = productCategoryRepository.Get(command.Id);
            if (productcategory == null)
                return;
            productcategory.Edit(command.Name);
            productCategoryRepository.SaveChanges();
        }

        public List<CategoryViewModel> GetAll()
        {
            return productCategoryRepository.GetAll();
        }

        public EditCategory GetDetails(int Id)
        {
            return productCategoryRepository.GetDetails(Id);
        }

        public List<CategoryViewModel> Search(string name)
        {
            return productCategoryRepository.Search(name);
        }
    }
}
