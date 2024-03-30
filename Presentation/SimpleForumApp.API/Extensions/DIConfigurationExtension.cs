using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;
using SimpleForumApp.Persistence.Helpers;
using SimpleForumApp.Persistence.Repositories;
using SimpleForumApp.Persistence.UnitOfWorks;

namespace SimpleForumApp.API.Extensions
{
    public static class DIConfigurationExtension
    {
        public static void ConfigureDIContainer(this IServiceCollection services)
        {
            // For Entity Framework Core
            var connectionString = AppSettingsReaderHelper.GetSqlServerConnectionString();
            services.AddDbContext<SimpleForumAppContext>(options => options.UseSqlServer(connectionString));

            // For UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // For Repositories
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
        }
    }
}
