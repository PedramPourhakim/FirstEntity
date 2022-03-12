using EfFirstLibrary.Mapping;
using EfFirstLibrary.ProductCategory;
using EfFirstLibrary.TheProduct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfFirstLibrary.Context
{
    public class EfContext :DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public EfContext(DbContextOptions<EfContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
