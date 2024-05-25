using Microsoft.AspNetCore.Identity;
using SimpleForumApp.Application.Repositories.PersonRepositories;
using SimpleForumApp.Application.Services.Auth;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Application.UnitOfWork.Context;
using SimpleForumApp.Application.UnitOfWork.Database;
using SimpleForumApp.Infrastructure.Services.Auth;
using SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.PersonRepositories;
using SimpleForumApp.Persistence.UnitOfWork;
using SimpleForumApp.Persistence.UnitOfWork.Context;
using SimpleForumApp.Persistence.UnitOfWork.Database;

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
            services.AddScoped<IContext, Context>();
            services.AddScoped<IDatabase, Database>();
            services.AddScoped<IAppContext, Persistence.UnitOfWork.Context.AppContext>();
            services.AddScoped<IIdentityContext, IdentityContext>();
            services.AddScoped<IEfCoreDb, EfCoreDb>();

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
