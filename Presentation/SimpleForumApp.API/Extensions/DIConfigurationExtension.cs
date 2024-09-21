using SimpleForumApp.Application.Helpers;
using SimpleForumApp.Application.Repositories.App;
using SimpleForumApp.Application.Repositories.Auth;
using SimpleForumApp.Application.Repositories.Traceability;
using SimpleForumApp.Application.Services.Auth;
using SimpleForumApp.Application.Services.Email;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Application.UnitOfWork.Context;
using SimpleForumApp.Application.UnitOfWork.Database;
using SimpleForumApp.Infrastructure.Services.Auth;
using SimpleForumApp.Infrastructure.Services.Email;
using SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.App;
using SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.Auth;
using SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.Traceability;
using SimpleForumApp.Persistence.UnitOfWork;
using SimpleForumApp.Persistence.UnitOfWork.Context;
using SimpleForumApp.Persistence.UnitOfWork.Database;
using System.Net;
using System.Net.Mail;

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

            // Contexts
            services.AddScoped<IContext, Context>();
            services.AddScoped<IAppContext, Persistence.UnitOfWork.Context.AppContext>();
            services.AddScoped<IIdentityContext, IdentityContext>();
            services.AddScoped<INotificationContext, NotificationContext>();
            services.AddScoped<ITraceabilityContext, TraceabilityContext>();
            services.AddScoped<IAuthContext, AuthContext>();

            // Databases
            services.AddScoped<IDatabase, Database>();
            services.AddScoped<IEfCoreDb, EfCoreDb>();

            // App Repositories
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();

            // Traceability Repositories
            services.AddScoped<IEndPointRepository, EndPointRepository>();
            services.AddScoped<IEndPointActivityRepository, EndPointActivityRepository>();

            // Auth Repositories
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<IEndPointPermissionRepository, EndPointPermissonRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IClaimBusinessRuleRepository, ClaimBusinessRuleRepository>();
            services.AddScoped<IEndPointClaimBusinessRuleRepository, EndPointClaimBusinessRuleRepository>();

            // For Smpt
            services.AddScoped<SmtpClient>(opt =>
            {
                var smtp = new SmtpClient();

                smtp.Host = AppSettingsReaderHelper.GetEmailSettingsHost();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(AppSettingsReaderHelper.GetEmailSettingsEmail(), AppSettingsReaderHelper.GetEmailSettingsPassword());
                smtp.EnableSsl = true;

                return smtp;
            });
        }

        #endregion

        #region Infrastructure

        private static void ConfigureInfrastructureLayerDependencies(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IEmailService, EmailService>();
        }

        #endregion
    }
}
