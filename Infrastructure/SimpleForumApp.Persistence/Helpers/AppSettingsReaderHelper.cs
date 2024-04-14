using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Persistence.Helpers
{
    public static class AppSettingsReaderHelper
    {
        public static string GetSqlServerConnectionString()
        {
            ConfigurationManager manager = new();

            manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/SimpleForumApp.API"));
            manager.AddJsonFile("appsettings.json");

            return manager.GetConnectionString("SqlServer");
        }
    }
}
