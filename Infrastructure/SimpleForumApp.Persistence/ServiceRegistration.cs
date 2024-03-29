using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleForumApp.Application.Repositories;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;
using SimpleForumApp.Persistence.Helpers;
using SimpleForumApp.Persistence.Repositories;
using SimpleForumApp.Persistence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            var connectionString = AppSettingsReaderHelper.GetSqlServerConnectionString();

            services.AddDbContext<SimpleForumAppContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
        }
    }
}
