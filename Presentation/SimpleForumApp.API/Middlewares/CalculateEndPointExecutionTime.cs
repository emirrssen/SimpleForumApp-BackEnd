namespace SimpleForumApp.API.Middlewares
{
    public class CalculateEndPointExecutionTime
    {
        private readonly RequestDelegate _next;

        public CalculateEndPointExecutionTime(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CalculateEndPointExecutionTimeExtensions
    {
        public static IApplicationBuilder UseCalculateEndPointExecutionTime(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CalculateEndPointExecutionTime>();
        }
    }
}
