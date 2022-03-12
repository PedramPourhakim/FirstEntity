using EfFirstLibrary.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfFirstLibrary.ProductCategory
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly EfContext efContext;
        public ProductCategoryRepository(EfContext efContext)
        {
            this.efContext = efContext;
        }
        public void Create(Category category)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public void Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public EditCategory GetDetails(int Id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            efContext.SaveChanges();
        }

        public List<CategoryViewModel> Search(string Name)
        {
            throw new NotImplementedException();
        }
    }
}
