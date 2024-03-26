using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;
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
            services.AddDbContext<SimpleForumAppContext>(options => options.UseSqlServer("Server=localhost;Database=SimpleForumApp;User Id=SA; Password=1323240950-Ee;TrustServerCertificate=True"));
        }
    }
}
