using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SimpleForumApp.API.Filters;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;
using SimpleForumApp.Persistence.Helpers;

namespace SimpleForumApp.API.Extensions
{
    public static class PackageConfigurationsExtension
    {
        public static void ConfigurePackages(this IServiceCollection services)
        {
            ConfigureMediatR(services);
            ConfigureFluentValidation(services);
            ConfigureIdentity(services);
            ConfigureEntityFramework(services);
        }

        #region MediatR

        private static void ConfigureMediatR(IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<IUnitOfWork>());
        }

        #endregion

        #region Fluent Validation

        private static void ConfigureFluentValidation(IServiceCollection services)
        {
            services.AddControllers(option => option.Filters.Add(new ValidationResultFilter()))
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<IUnitOfWork>());
        }

        #endregion

        #region Identity

        private static void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<SimpleForumAppContext>();
        }

        #endregion

        #region Entity Framework Core

        private static void ConfigureEntityFramework(IServiceCollection services)
        {
            var connectionString = AppSettingsReaderHelper.GetSqlServerConnectionString();
            services.AddDbContext<SimpleForumAppContext>(options => options.UseSqlServer(connectionString));
        }

        #endregion
    }
}
