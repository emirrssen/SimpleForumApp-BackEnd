using Microsoft.AspNetCore.Identity;
using SimpleForumApp.Application.Repositories.PersonRepositories;
using SimpleForumApp.Application.Services.Auth;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Infrastructure.Services.Auth;
using SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.PersonRepositories;
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
            services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
            services.AddScoped<IIdentityUnitOfWork, IdentityUnitOfWork>();

            // For Repositories
            services.AddScoped<IPersonWriteRepository, PersonWriteRepository>();
        }

        #endregion

        #region Infrastructure

        private static void ConfigureInfrastructureLayerDependencies(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
        }

        #endregion
    }
}
