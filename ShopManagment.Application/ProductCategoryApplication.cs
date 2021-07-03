using ShopManagment.Application.Contract.ProductCategory;
using ShopManegment.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace ShopManagment.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication

    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var Operation = new OperationResult();
            if (_productCategoryRepository.Exist(x=>x.Name == command.Name))
            {
                return Operation.Failed("امکان ثبت رکورد تکراری وجود ندارد لطفا مجدد تلاش  بفرمایدد ");


            }

            var slug = command.Slug.SlugifyGenerate();

            var productCategory = new ProductCategory(command.Name, command.Description
                , command.Picture, command.PictureAlt, command.Keywords
                , command.MetaDescription, slug, command.PictureTitle);
            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();
            return Operation.Succeeded();

        }

        public OperationResult Edit(EditProductCategory command)
        {
            var Operation = new OperationResult();
            var productCategory = _productCategoryRepository.GetBy(command.Id);
            if (productCategory==null)
            {
                return Operation.Failed("رکورد با اطلاعات درخواست شده یافت نشد ، مجدد تلاش بفرمایید");

            }

            if (_productCategoryRepository.Exist(x=>x.Name==command.Name && x.Id!=command.Id))
            {
                return Operation.Failed("رکورد با اطلاعات درخواست شده یافت نشد ، مجدد تلاش بفرمایید");
            }

            var slug = command.Slug.SlugifyGenerate();

            productCategory.Edit(command.Name,command.Description
            ,command.Picture,command.PictureAlt
            ,command.Keywords,command.MetaDescription
            ,slug,command.PictureTitle);
            _productCategoryRepository.SaveChanges();
            return Operation.Succeeded();

        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);

        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }
    }
}
