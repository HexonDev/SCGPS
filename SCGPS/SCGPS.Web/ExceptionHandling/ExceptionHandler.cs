using SCGPS.Domain;
using SCGPS.Domain.Dto;
using SCGPS.Domain.Exceptions;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace SCGPS.Web.ExceptionHandling
{
	public class ExceptionHandler
	{
		private readonly RequestDelegate _next;

		public ExceptionHandler(RequestDelegate next)
		{
			_next = next ?? throw new ArgumentNullException(nameof(next));
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (Exception ex)
			{
				var nEx = ex.GetException();
				await HandleResponseAsync(httpContext, nEx);
			}
		}

		private static async Task HandleResponseAsync(HttpContext context, ScGpsException exception)
		{
			context.Response.ContentType = MediaTypeNames.Application.Json;
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			await context.Response.WriteAsync(JsonSerializer.Serialize(new BaseDto
			{
				IsSucceded = false,
				ErrorCode = $"{(int)exception.ErrorCode}",
				ErrorDescription = exception.ErrorCode.GetErrorDescription(),
				Time = DateTime.Now,
			}, new JsonSerializerOptions()
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				WriteIndented = true,
			}));
		}
	}
}
