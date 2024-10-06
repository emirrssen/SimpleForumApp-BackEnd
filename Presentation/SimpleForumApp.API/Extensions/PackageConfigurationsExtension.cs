using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SimpleForumApp.API.Filters;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Infrastructure.Configurations.Identity;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;
using SimpleForumApp.Application.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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
            ConfigureJwt(services);
            ConfigureCaching(services);
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
            // For Lifetime Of Generated Tokens
            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromMinutes(5);
            });

            services.AddIdentity<User, AspIdentityRole>(options =>
            {
                // For Password
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;

                // For User
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<SimpleForumAppContext>()
                .AddPasswordValidator<PasswordValidationConfigurations>()
                .AddUserValidator<UserValidationConfigurations>()
                .AddErrorDescriber<ValidationMessageConfigurations>()
                .AddDefaultTokenProviders();
        }

        #endregion

        #region Entity Framework Core

        private static void ConfigureEntityFramework(IServiceCollection services)
        {
            var connectionString = AppSettingsReaderHelper.GetSqlServerConnectionString();
            services.AddDbContext<SimpleForumAppContext>(options => options.UseSqlServer(connectionString));
        }

        #endregion

        #region JWT

        private static void ConfigureJwt(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("simple-forum-app", options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidAudience = AppSettingsReaderHelper.GetTokenAudience(),
                        ValidIssuer = AppSettingsReaderHelper.GetTokenIssuer(),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettingsReaderHelper.GetTokenSecurityKey())),

                        LifetimeValidator = (notBefore, expires, securityToken, validationParameters)
                            => expires != null ? expires > DateTime.UtcNow : false,

                        NameClaimType = ClaimTypes.Name,
                    };
                });
        }

        #endregion

        #region Cache

        public static void ConfigureCaching(IServiceCollection services)
        {
            ConfigureInMemoryCaching(services);
            ConfigureRedisCaching(services);
        }

        // In Memory
        public static void ConfigureInMemoryCaching(IServiceCollection services) => services.AddMemoryCache();

        // Redis
        public static void ConfigureRedisCaching(IServiceCollection services) 
            => services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = AppSettingsReaderHelper.GetRedisServer();
        });

        #endregion
    }
}
