using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfFirstLibrary.TheProduct
{
    public interface IProductRepository
    {
        Product Get(int Id);
        EditProduct GetDetails(int Id);
        void Create(Product product);
        public void SaveChanges();
        public bool Exists(string Name,int CategoryId);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
