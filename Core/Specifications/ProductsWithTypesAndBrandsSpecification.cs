using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParam productParams) 
            : base(x => 
                (string.IsNullOrEmpty(productParams.Search) || 
                 x.Name.ToLower().Contains(productParams.Search)) &&
                (!productParams.BrandId.HasValue || x.ProductBrand.Id == productParams.BrandId) && 
                (!productParams.TypeId.HasValue || x.ProductType.Id == productParams.TypeId)) 
        {
           AddInclude(x => x.ProductType);
           AddInclude(x => x.ProductBrand);
           AddOrderBy(x => x.Name);
           ApplyPaging(productParams.PageSize*(productParams.PageIndex - 1),productParams.PageSize);

           if (!string.IsNullOrEmpty(productParams.Sort))
           {
               switch (productParams.Sort)
               {    
                   case "priceAsc":
                       AddOrderBy(p => p.Price);
                       break;
                   case "priceDesc":
                       AddOrderByDescending(p => p.Price);
                       break;
                   default: 
                       AddOrderBy(p => p.Price);
                       break;
               }
           }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}