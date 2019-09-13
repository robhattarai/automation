using System;
using System.Configuration;

namespace Selenium
{
    public class AppVariables
    {
        public static string URL { get; set; }

        public string GetURL() { return ConfigurationManager.AppSettings["URL"]; }
    }
}
