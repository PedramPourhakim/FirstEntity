using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfFirstLibrary.TheProduct
{
    public interface IProductApplication
    {
        void Creat(CreateProduct command);
        void Edit(EditProduct command);
        void Remove(int Id);
        void Restore(int Id);
        EditProduct GetDetails(int Id);
        public List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
