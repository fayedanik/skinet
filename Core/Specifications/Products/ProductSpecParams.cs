using System;
using SharedKernel.Enums;

namespace Core.Specifications.Products
{
	public class ProductSpecParams : BaseSpecParams
	{
        public int? ProductBrandId { get; set; }

        public int? ProductTypeId { get; set; }
    }
}

