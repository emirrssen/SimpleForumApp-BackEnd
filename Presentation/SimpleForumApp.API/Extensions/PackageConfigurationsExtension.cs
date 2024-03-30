using FluentValidation.AspNetCore;
using SimpleForumApp.API.Filters;
using SimpleForumApp.Application.UnitOfWork;

namespace SimpleForumApp.API.Extensions
{
    public static class PackageConfigurationsExtension
    {
        public static void ConfigurePackages(this IServiceCollection services)
        {
            // For MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<IUnitOfWork>());

            // For FluentValidation
            services.AddControllers(option => option.Filters.Add(new ValidationResultFilter()))
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<IUnitOfWork>());
        }
    }
}
