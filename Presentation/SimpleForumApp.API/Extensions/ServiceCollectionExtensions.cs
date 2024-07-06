using SimpleForumApp.API.Filters;

namespace SimpleForumApp.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEndPointExecuitonTimeCalculationFilterToEndPoints(this IServiceCollection services)
        {
            services.AddScoped<CalculateEndPointExecutionTimeFilter>();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<CalculateEndPointExecutionTimeFilter>();
            });
        }
    }
}
