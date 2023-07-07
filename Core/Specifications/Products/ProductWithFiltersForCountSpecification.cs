using System;
using Core.Entities;

namespace Core.Specifications.Products
{
	public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
	{
		public ProductWithFiltersForCountSpecification(ProductSpecParams specParams)
            : base(x =>
                (string.IsNullOrEmpty(specParams.SearchText) || x.Name.ToLower().Contains(specParams.SearchText)) &&
                (!specParams.ProductTypeId.HasValue || x.ProductTypeId == specParams.ProductTypeId) &&
                (!specParams.ProductBrandId.HasValue || x.ProductBrandId == specParams.ProductBrandId)
            )
        {

		}
	}
}

