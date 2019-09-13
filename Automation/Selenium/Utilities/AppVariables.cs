using System;
using System.Configuration;

namespace Selenium
{
    public class AppVariables
    {
        public static string URL { get; set; }
        public static string SAUCELABS_USERNAME { get; set; }
        public static string SAUCELABS_ACCESSKEY { get; set; }
        public static string BROWSERSTACK_USERNAME { get; set; }
        public static string BROWSERSTACK_ACCESSKEY { get; set; }

        public static string GetURL() { return ConfigurationManager.AppSettings["URL"]; }
        public static string GetSAUCELABS_USERNAME() { return ConfigurationManager.AppSettings["SAUCELABS_USERNAME"]; }
        public static string GetSAUCELABS_ACCESSKEY() { return ConfigurationManager.AppSettings["SAUCELABS_ACCESSKEY"]; }
        public static string GetBROWSERSTACK_USERNAME() { return ConfigurationManager.AppSettings["BROWSERSTACK_USERNAME"]; }
        public static string GetBROWSERSTACK_ACCESSKEY() { return ConfigurationManager.AppSettings["BROWSERSTACK_ACCESSKEY"]; }
    }
}
