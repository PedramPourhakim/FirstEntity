using EfFirstLibrary.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfFirstLibrary.Product
{
     public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public bool IsRemoved { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreationDate { get; set; }
        public Product(string Name,double UnitPrice,int CategoryId)
        {
            this.Name = Name;
            this.UnitPrice = UnitPrice;
            this.CategoryId = CategoryId;
            CreationDate = DateTime.Now;
        }
        public void IsDeleted()
        {
            IsRemoved = true;
        }
        public void IsRestored()
        {
            IsRemoved = false;
        }
        public void Edit(string Name,double UnitPrice,int CategoryId)
        {
            this.Name = Name;
            this.UnitPrice = UnitPrice;
            this.CategoryId = CategoryId;
        }
    }
    
}
