using System;
using Core.Entities;
using SharedKernel.Enums;

namespace Core.Specifications.Products
{
	public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
	{
		public ProductsWithTypesAndBrandsSpecification(ProductSpecParams specParams)
			: base( x =>
				( string.IsNullOrEmpty(specParams.SearchText) || x.Name.ToLower().Contains(specParams.SearchText)) && 
				(!specParams.ProductTypeId.HasValue || x.ProductTypeId == specParams.ProductTypeId) &&
				(!specParams.ProductBrandId.HasValue || x.ProductBrandId == specParams.ProductBrandId)
			)

		{
			AddInclude(x => x.ProductBrand);
			AddInclude(x => x.ProductType);
			AddOrderBy(x => x.Name);

			if( !string.IsNullOrEmpty(specParams.OrderBy) )
			{
				switch (specParams.OrderType)
				{
                    case OrderType.Ascending:
						if(specParams.OrderBy == nameof(Product.Price)) AddOrderBy(x => x.Price);
						break;
					case OrderType.Descending:
						if (specParams.OrderBy == nameof(Product.Price)) AddOrderByDesc(x => x.Price);
						break;
					default:
						break;
				}
			}

			ApplyPagination(specParams.PageLimit, (specParams.PageNumber - 1) * specParams.PageLimit); 

		}

		public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
		{
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }

	}
}

