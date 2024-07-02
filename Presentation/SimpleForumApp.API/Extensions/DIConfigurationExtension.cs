using SimpleForumApp.Application.Helpers;
using SimpleForumApp.Application.Repositories;
using SimpleForumApp.Application.Repositories.PersonRepositories;
using SimpleForumApp.Application.Services.Auth;
using SimpleForumApp.Application.Services.Email;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Application.UnitOfWork.Context;
using SimpleForumApp.Application.UnitOfWork.Database;
using SimpleForumApp.Infrastructure.Services.Auth;
using SimpleForumApp.Infrastructure.Services.Email;
using SimpleForumApp.Persistence.EntityFrameworkCore.Repositories;
using SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.PersonRepositories;
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
            services.AddScoped<IContext, Context>();
            services.AddScoped<IDatabase, Database>();
            services.AddScoped<IAppContext, Persistence.UnitOfWork.Context.AppContext>();
            services.AddScoped<IIdentityContext, IdentityContext>();
            services.AddScoped<INotificationContext, NotificationContext>();
            services.AddScoped<IEfCoreDb, EfCoreDb>();

            // For Repositories
            services.AddScoped<IPersonWriteRepository, PersonWriteRepository>();
            services.AddScoped<IPersonReadRepository, PersonReadRepository>();
            services.AddScoped<IEndPointRepository, EndPointRepository>();

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
