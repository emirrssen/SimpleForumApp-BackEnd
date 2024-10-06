﻿using Microsoft.Extensions.Configuration;

namespace SimpleForumApp.Application.Helpers
{
    public static class AppSettingsReaderHelper
    {
        public static string GetSqlServerConnectionString() => Manager().GetConnectionString("SqlServer");
        public static string GetTokenAudience() => Manager().GetValue<string>("Token:Audience");
        public static string GetTokenIssuer() => Manager().GetValue<string>("Token:Issuer");
        public static string GetTokenSecurityKey() => Manager().GetValue<string>("Token:SecurityKey");
        public static string GetEmailSettingsHost() => Manager().GetValue<string>("EmailSettings:Host");
        public static string GetEmailSettingsPassword() => Manager().GetValue<string>("EmailSettings:Password");
        public static string GetEmailSettingsEmail() => Manager().GetValue<string>("EmailSettings:Email");
        public static string GetRedisServer() => Manager().GetValue<string>("Redis:Server");

        private static ConfigurationManager Manager()
        {
            ConfigurationManager manager = new();

            manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/SimpleForumApp.API"));
            manager.AddJsonFile("appsettings.json");

            return manager;
        }
    }
}
