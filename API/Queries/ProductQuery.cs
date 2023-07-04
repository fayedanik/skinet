using System;
using Core.Specifications.Products;

namespace API.Queries
{
	public class ProductQuery : BaseQuery
	{
		public int? ProductTypeId { get; set; }
		public int? ProductBrandId { get; set; }

        public static ProductSpecParams CreateProductSpecParam(ProductQuery query)
		{
			return new ProductSpecParams
			{
				PageNumber = query.PageNumber,
				PageLimit = query.PageLimit,
				OrderBy = query.OrderBy,
				OrderType = query.OrderType,
				SearchText = query.SearchText,
				ProductBrandId = query.ProductBrandId,
				ProductTypeId = query.ProductTypeId
			};
		}

    }

	
}

