using System;
using SharedKernel.Enums;

namespace Core.Specifications
{
	public class BaseSpecParams
	{
        public int PageLimit { get; set; }

        public int PageNumber { get; set; }

        public string? SearchText { get; set; }

        public string? OrderBy { get; set; }

        public OrderType OrderType { get; set; }
    }
}

