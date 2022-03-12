using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfFirstLibrary.ProductCategory
{
    public interface IProductCategoryApplication
    {
        public void Create(CreateCategory command);
        public void Edit(EditCategory command);
        public EditCategory GetDetails(int Id);
        public List<CategoryViewModel> GetAll();
        public List<CategoryViewModel> Search(string name);
    }
}
