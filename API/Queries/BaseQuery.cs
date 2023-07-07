using System;
using SharedKernel.Enums;

namespace API.Queries
{
	public class BaseQuery
	{
		private int MaxPageSize { get; set; } = 50;

		public string? OrderBy { get; set; }

		public OrderType OrderType { get; set; }

		private int _PageLimit { get; set; } = 5;

		public int PageLimit
		{
			get => _PageLimit;
			set => _PageLimit = (value > MaxPageSize) ? MaxPageSize : value;
		}

		public int PageNumber { get; set; } = 1;

		public string?  SearchText { get; set; }
	}
}

