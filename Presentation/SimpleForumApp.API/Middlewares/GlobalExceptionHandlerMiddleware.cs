using Microsoft.EntityFrameworkCore.Storage;
using SimpleForumApp.Domain.Results;
using System.Net;
using System.Text.Json;

namespace SimpleForumApp.API.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;

            var resultException = JsonSerializer.Serialize(new ResultWithException
            {
                Title = "Unexpected Error Occurred",
                Errors = new()
                {
                    exception.Message.ToString()
                },
                StatusCode = statusCode
            });

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(resultException);
        }
    }
}
