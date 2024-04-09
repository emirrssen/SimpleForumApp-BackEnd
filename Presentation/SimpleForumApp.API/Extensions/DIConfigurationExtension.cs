using SimpleForumApp.Application.Repositories;
using SimpleForumApp.Application.Services.Auth;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Infrastructure.Services.Auth;
using SimpleForumApp.Persistence.EntityFrameworkCore.Repositories;
using SimpleForumApp.Persistence.UnitOfWork;

namespace SimpleForumApp.API.Extensions
{
    public static class DIConfigurationExtension
    {
        public static void ConfigureDIContainer(this IServiceCollection services)
        {
            ConfigurePersistenceLayerDependencies(services);
            ConfigureInfrastructureLayerDependencies(services);
        }

        #region Persistence

        private static void ConfigurePersistenceLayerDependencies(IServiceCollection services)
        {
            // For UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // For Repositories
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
        }

        #endregion

        #region Infrastructure

        private static void ConfigureInfrastructureLayerDependencies(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        #endregion
    }
}
