using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegment.Domain.ProductCategoryAgg
{
   public interface IProductCategoryRepository
   {
       void Create( ProductCategory entity);
       ProductCategory GetBy(long id);
       List<ProductCategory> GetAll();



   }
}
