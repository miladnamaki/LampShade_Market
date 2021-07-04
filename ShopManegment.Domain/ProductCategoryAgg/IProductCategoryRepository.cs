
using System.Collections.Generic;

using _00_Fromwork.Domain;
using ShopManagment.Application.Contract.ProductCategory;


namespace ShopManegment.Domain.ProductCategoryAgg
{
   public interface IProductCategoryRepository:IRepository<long,ProductCategory>
   {
      
       
       EditProductCategory GetDetails(long id);
       List<ProductCategoryViewModel> Search(ProductCategorySearchModel Searchmodel);


   }
}
