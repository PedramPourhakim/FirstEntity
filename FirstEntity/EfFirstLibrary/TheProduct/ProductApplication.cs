﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfFirstLibrary.TheProduct
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository productRepository;
        public ProductApplication(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Creat(CreateProduct command)
        {
            if (productRepository.Exists(command.Name, command.CategoryId))
                return;
            var product = new Product(command.Name,command.UnitPrice,command.CategoryId);
            productRepository.Create(product);
            productRepository.SaveChanges();
        }

        public void Edit(EditProduct command)
        {
            var product = productRepository.Get(command.Id);
            if (product == null)
                return;
            product.Edit(command.Name, command.UnitPrice, command.CategoryId);
            productRepository.SaveChanges();
        }

        public EditProduct GetDetails(int Id)
        {
            return productRepository.GetDetails(Id);
        }

        public void Remove(int Id)
        {
            var product = productRepository.Get(Id);
            if (product == null)
                return;
            product.IsDeleted();
            productRepository.SaveChanges();
        }

        public void Restore(int Id)
        {
            var product = productRepository.Get(Id);
            if (product == null)
                return;
            product.IsRestored();
            productRepository.SaveChanges();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return productRepository.Search(searchModel);
        }
    }
}
