using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopManagment.Application.Contract.ProductCategory;


namespace ShopManegment.Domain.ProductCategoryAgg
{
   public interface IProductCategoryRepository
   {
       void Create( ProductCategory entity);
       ProductCategory GetBy(long id);
       List<ProductCategory> GetAll();
       bool Exist(Expression<Func<ProductCategory, bool>> filter );
       void SaveChanges();
       EditProductCategory GetDetails(long id);
       List<ProductCategoryViewModel> Search(ProductCategorySearchModel Searchmodel);


   }
}
