﻿using System;
namespace API.Errors
{
	public class ApiResponse
	{
		public ApiResponse(int statusCode,string? errorMessage = null)
		{
			StatusCode = statusCode;
			ErrorMessage = errorMessage ?? GetDefaultErrorMessage(statusCode);
		}

        public int StatusCode { get; set; }

		public string? ErrorMessage { get; set; }

        private string? GetDefaultErrorMessage(int statusCode)
        {
			return statusCode switch
			{
				400 => "Bad Request",
				401 => "Unauthroized Action",
				404 => "Resource not Found",
				500 => "Internal Server Error",
				501 => "Not Implemented",
				_ => null
			};
        }
    }
}

