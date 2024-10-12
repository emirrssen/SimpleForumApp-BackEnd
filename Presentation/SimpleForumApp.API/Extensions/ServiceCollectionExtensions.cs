using SimpleForumApp.API.Filters;

namespace SimpleForumApp.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEndPointExecuitonTimeCalculationFilterToEndPoints(this IServiceCollection services)
        {
            services.AddScoped<CalculateEndPointExecutionTimeFilter>();
            services.AddScoped<RolePermissionFilterFromCache>();
            services.AddScoped<RunClaimBusinessRulesFilter>();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<CalculateEndPointExecutionTimeFilter>();
                options.Filters.Add<RolePermissionFilterFromCache>();
                options.Filters.Add<RunClaimBusinessRulesFilter>();
            });
        }
    }
}


