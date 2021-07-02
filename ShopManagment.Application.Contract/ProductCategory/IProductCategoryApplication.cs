

using System;
using System.Collections.Generic;

namespace ShopManagment.Application.Contract.ProductCategory
{
     public interface IProductCategoryApplication
     {
         void Create(CreateProductCategory command);
         void Edit(EditProductCategory command);
         ShopManegment.Domain.ProductCategoryAgg.ProductCategory GetAll(long id);
         List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);

     }
}
