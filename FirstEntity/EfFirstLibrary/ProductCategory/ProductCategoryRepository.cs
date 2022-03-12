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
            efContext.Categories.Add(category);
            SaveChanges();
        }

        public bool Exists(string name)
        {
            return efContext.Categories.Any(x => x.Name == name);
        }

        public Category Get(int Id)
        {
            return efContext.Categories.FirstOrDefault(x => x.Id == Id);
        }

        public List<CategoryViewModel> GetAll()
        {
            return efContext.Categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToString()
            }).ToList();
        }

        public EditCategory GetDetails(int Id)
        {
            return efContext.Categories.Select(x => new EditCategory
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault(x => x.Id == Id);
         
        }

        public void SaveChanges()
        {
            efContext.SaveChanges();
        }

        public List<CategoryViewModel> Search(string Name)
        {
            var query = efContext.Categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToString()
            });
            if (!string.IsNullOrWhiteSpace(Name))
                query = query.Where(x => x.Name.Contains(Name));
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
