using System;
using SharedKernel.Enums;

namespace Core.Specifications
{
	public class BaseSpecParams
	{
        public int PageLimit { get; set; }

        public int PageNumber { get; set; }

        public string? SearchText
        {
            get => _SearchText;
            set => _SearchText = !string.IsNullOrWhiteSpace(value) ? value.ToLower() : string.Empty;
        }

        public string _SearchText { get; set; } = string.Empty;

        public string? OrderBy { get; set; }

        public OrderType OrderType { get; set; }
    }
}

