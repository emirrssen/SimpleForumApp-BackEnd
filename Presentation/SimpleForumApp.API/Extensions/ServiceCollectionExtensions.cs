using SimpleForumApp.API.Filters;

namespace SimpleForumApp.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEndPointExecuitonTimeCalculationFilterToEndPoints(this IServiceCollection services)
        {
            services.AddScoped<CalculateEndPointExecutionTimeFilter>();
            services.AddScoped<RolePermissionFilter>();
            services.AddScoped<RunClaimBusinessRulesFilter>();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<CalculateEndPointExecutionTimeFilter>();
                options.Filters.Add<RolePermissionFilter>();
                options.Filters.Add<RunClaimBusinessRulesFilter>();
            });

            services.AddMemoryCache();
        }
    }
}


