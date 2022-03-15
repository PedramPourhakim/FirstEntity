using EfFirstLibrary.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfFirstLibrary.TheProduct
{
    public class ProductRepository : IProductRepository
    {
        private readonly EfContext efContext;
        public ProductRepository(EfContext efContext)
        {
            this.efContext = efContext;
        }
        public void Create(Product product)
        {
            efContext.Products.Add(product);
        }

        public bool Exists(string Name, int CategoryId)
        {
            return efContext.Products.Any(x => x.Name == Name && x.CategoryId == CategoryId);

        }

        public Product Get(int Id)
        {
            return efContext.Products.FirstOrDefault(x=>x.Id==Id);
        }

        public EditProduct GetDetails(int Id)
        {
            return efContext.Products.Select(x => new EditProduct
            {
                Id = x.Id,
                Name = x.Name,
                UnitPrice = x.UnitPrice,
                CategoryId = x.CategoryId
            }).FirstOrDefault(x => x.Id == Id);
        }

        public void SaveChanges()
        {
            efContext.SaveChanges();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = efContext.Products.Select(x => new ProductViewModel
            {
                Name = x.Name,
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                IsRemoved = x.IsRemoved,
                CreationDate = x.CreationDate.ToString(),
                Category=x.Category.Name
            }) ;
            if (searchModel.IsRemoved == true)
                query = query.Where(x => x.IsRemoved == true);
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            return query.OrderByDescending(x => x.Id).AsNoTracking().ToList();
             
        }
    }
}
