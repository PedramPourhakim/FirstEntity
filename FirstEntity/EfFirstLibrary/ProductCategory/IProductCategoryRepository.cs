using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfFirstLibrary.ProductCategory
{
    public interface IProductCategoryRepository
    {
        public void Get(int Id);
        public void Create(Category category);
        public bool Exists(string name);
        public void SaveChanges();
        public EditCategory GetDetails(int Id);
        public List<CategoryViewModel> Search(string Name);
        public List<CategoryViewModel> GetAll();
    }
}
