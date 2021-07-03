

using ShopManagment.Application.Contract.ProductCategory;
using ShopManegment.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository

    {
        private readonly ShopContext _Context;

        public ProductCategoryRepository(ShopContext shopContext)
        {
            _Context = shopContext;
        }

        public void Create(ProductCategory entity)
        {
            _Context.ProductCategories.Add(entity);
        }

        public bool Exist(Expression<Func<ProductCategory, bool>> filter)
        {
            return _Context.ProductCategories.Any(filter);

        }

        public List<ProductCategory> GetAll()
        {
            return _Context.ProductCategories.ToList();

        }

        public ProductCategory GetBy(long id)
        {
            return _Context.ProductCategories.Find(id);
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

        public void SaveChanges()
        {
            _Context.SaveChanges();
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
