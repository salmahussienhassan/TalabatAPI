using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Core.Specifications
{
    public class ProductSpecification:BaseSpecification<Product>
    {
        //GetAllProduct
        public  ProductSpecification(ProductSpecParams Params) : base(
            p=> (!Params.BrandId.HasValue || p.ProductBrandId== Params.BrandId)
            &&
            (!Params.TypeId.HasValue || p.ProductTypeId==Params.TypeId))
        {
            IncludeExpressions.Add(p => p.ProductBrand);
            IncludeExpressions.Add(p => p.ProductType);

            if(!string.IsNullOrEmpty(Params.Sort))
            switch(Params.Sort)
            {
                    case "PriceAsc":
                        AddOrderBy(p => p.Price);
                    break;

                    case "PriceDesc":
                        AddOrderDescBy(p => p.Price);
                        break;

                        default: 
                        AddOrderBy(p => p.Name);
                        break;
                }

            ApplyPagination(Params.PageSize * (Params.PageIndex - 1), Params.PageSize);

        }
        //GetProductById
       public ProductSpecification(int id) :base(p=>p.Id ==id) 
        {
            IncludeExpressions.Add(p => p.ProductBrand);
            IncludeExpressions.Add(p => p.ProductType);
        }

        

    }
}
