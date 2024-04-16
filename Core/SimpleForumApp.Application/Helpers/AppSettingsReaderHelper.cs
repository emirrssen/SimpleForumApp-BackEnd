using Microsoft.Extensions.Configuration;

namespace SimpleForumApp.Application.Helpers
{
    public static class AppSettingsReaderHelper
    {
        public static string GetSqlServerConnectionString() => Manager().GetConnectionString("SqlServer");
        public static string GetTokenAudience() => Manager().GetValue<string>("Token:Audience");
        public static string GetTokenIssuer() => Manager().GetValue<string>("Token:Issuer");
        public static string GetTokenSecurityKey() => Manager().GetValue<string>("Token:SecurityKey");

        private static ConfigurationManager Manager()
        {
            ConfigurationManager manager = new();

            manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/SimpleForumApp.API"));
            manager.AddJsonFile("appsettings.json");

            return manager;
        }
    }
}
