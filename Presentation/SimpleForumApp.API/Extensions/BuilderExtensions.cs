using SimpleForumApp.API.Middlewares;

namespace SimpleForumApp.API.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}
