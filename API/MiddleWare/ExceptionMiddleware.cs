﻿
using System;
using System.Net;
using System.Text.Json;
using API.Errors;

namespace API.MiddleWare
{
	public class ExceptionMiddleware
	{
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(
			RequestDelegate next,
			ILogger<ExceptionMiddleware>logger,
			IHostEnvironment env)
		{
			_next = next;
			_logger = logger;
			_env = env;
		}

        public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch( Exception ex )
			{
				_logger.LogError(ex,ex.Message);
				await HandleException(context,ex);
			}
		}

		private async Task HandleException(HttpContext context,Exception ex)
		{
            context.Response.ContentType = "applicaton/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			var response = _env.IsDevelopment() ?
				new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace?.ToString()) :
				new ApiException((int)HttpStatusCode.InternalServerError);
			var options = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};
			var json = JsonSerializer.Serialize(response,options);
			await context.Response.WriteAsync(json);
        }
    }
}

