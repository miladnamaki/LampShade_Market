using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Infrastructure.EfCore;
using ShopManagement.Infrastructure.EfCore.Repository;
using ShopManagment.Application;
using ShopManagment.Application.Contract.ProductCategory;
using ShopManegment.Domain.ProductCategoryAgg;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection services , string connectionstring)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionstring));
        }
             
    }
}
