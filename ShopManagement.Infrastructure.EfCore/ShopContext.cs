using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EfCore.Mapping;
using ShopManegment.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EfCore
{
    public  class ShopContext:DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set;  }

        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
