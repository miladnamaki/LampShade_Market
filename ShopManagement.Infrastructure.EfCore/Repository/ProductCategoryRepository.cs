

using ShopManagment.Application.Contract.ProductCategory;
using ShopManegment.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using _00_Fromwork.Infrastructure;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long,ProductCategory> ,IProductCategoryRepository

    {
        private readonly ShopContext _Context;

        public ProductCategoryRepository(ShopContext shopContext):base(shopContext)
        {
            _Context = shopContext;
        }


        public EditProductCategory GetDetails(long id)
        {
            return _Context.ProductCategories.Select(x => new EditProductCategory(){
                Id=x.Id,
                Description = x.Description,
                Name = x.Name,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                PictureAlt = x.PictureAlt,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,

            }).FirstOrDefault(x=>x.Id==id);
        }

       

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel Searchmodel)
        {
            var queryable = _Context.ProductCategories.Select(x => new ProductCategoryViewModel(){
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                CreationDate = x.CreationDate.ToString(),

            });
            if (!string.IsNullOrWhiteSpace(Searchmodel.Name))
                queryable = queryable.Where(x => x.Name.Contains(Searchmodel.Name));

            return queryable.OrderByDescending(x => x.Id).ToList();

        }
    }
}
