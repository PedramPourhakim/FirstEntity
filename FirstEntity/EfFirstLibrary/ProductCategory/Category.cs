using EfFirstLibrary.TheProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfFirstLibrary.ProductCategory
{
     public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public DateTime CreationDate { get; set; }
        public Category(string Name)
        {
            this.Name = Name;
            Products = new List<Product>();
            CreationDate = DateTime.Now;
        }
        public void Edit(string Name)
        {
            this.Name = Name;
        }
    }
}
