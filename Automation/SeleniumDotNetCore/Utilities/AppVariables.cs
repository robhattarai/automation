using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SeleniumDotNetCore
{
    public class AppVariables
    {
        public static IConfigurationRoot ReadAppSettingsJSON()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configBuilder = builder.Build();
            return configBuilder;
        }

        public static string URL { get; set; }
        public static string SAUCELABS_USERNAME { get; set; }
        public static string SAUCELABS_ACCESSKEY { get; set; }
        public static string BROWSERSTACK_USERNAME { get; set; }
        public static string BROWSERSTACK_ACCESS_KEY { get; set; }
        public static string BROWSERSTACK_LOCAL { get; set; }
        public static string BROWSERSTACK_LOCAL_IDENTIFIER { get; set; }

        public static string GetURL() { return ReadAppSettingsJSON().GetConnectionString("Url"); }
        public static string GetSAUCELABS_USERNAME() { return ReadAppSettingsJSON().GetConnectionString("SAUCELABS_USERNAME"); }
        public static string GetSAUCELABS_ACCESSKEY() { return ReadAppSettingsJSON().GetConnectionString("SAUCELABS_ACCESSKEY"); }
        public static string GetBROWSERSTACK_USERNAME() { return ReadAppSettingsJSON().GetConnectionString("BROWSERSTACK_USERNAME"); }
        public static string GetBROWSERSTACK_ACCESS_KEY() { return ReadAppSettingsJSON().GetConnectionString("BROWSERSTACK_ACCESS_KEY"); }
        public static string GetBROWSERSTACK_LOCAL() { return ReadAppSettingsJSON().GetConnectionString("BROWSERSTACK_LOCAL"); }
        public static string GetBROWSERSTACK_LOCAL_IDENTIFIER() { return ReadAppSettingsJSON().GetConnectionString("BROWSERSTACK_LOCAL_IDENTIFIER"); }
    }
}
