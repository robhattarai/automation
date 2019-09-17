using System;
using log4net;
using log4net.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Collections.Generic;

namespace Selenium
{
    [TestFixture]
    [Category("SauceLabTest"), Category("NUnit")]
    public class TestInit
    {
        public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IWebDriver driver;
 //       DriverOptions browserOptions;
 
        [SetUp]
        public void SetUp()
        {
            log.Info("Open Browser and Navigate URL: " + AppVariables.URL);
            XmlConfigurator.Configure();
         //   driver = new ChromeDriver();
            driver = BrowserStackConnectUsingBrowserSpecificOptions();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Url = AppVariables.GetURL();
        }


        public IWebDriver BrowserStackConnectUsingBrowserSpecificOptions()
        {
            ChromeOptions browserOptions = new ChromeOptions();
            browserOptions.AddAdditionalCapability("os", "Windows", true);
            browserOptions.AddAdditionalCapability("browser", "chrome", true);
            //browserOptions.AddAdditionalCapability("browserstack.tunnel", true, true);
            browserOptions.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name, true);
            browserOptions.AddAdditionalCapability("browserstack.user", AppVariables.GetBROWSERSTACK_USERNAME(), true);
            browserOptions.AddAdditionalCapability("browserstack.key", AppVariables.GetBROWSERSTACK_ACCESS_KEY(), true);
            //browserOptions.AddAdditionalCapability("browserstack.local", AppVariables.GetBROWSERSTACK_LOCAL(), true);
            //browserOptions.AddAdditionalCapability("browserstack.localIdentifier", AppVariables.GetBROWSERSTACK_LOCAL_IDENTIFIER(), true);
//          driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), browserOptions);
//          driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub/"), browserOptions);
            driver = new RemoteWebDriver(new Uri("https://" + AppVariables.GetBROWSERSTACK_USERNAME() + ":" + AppVariables.GetBROWSERSTACK_ACCESS_KEY()+ "@hub-cloud.browserstack.com/wd/hub/"), browserOptions);
            return driver;
        }

        public IWebDriver SauceLabsConnectUsingBrowserSpecificOptions()
        {
            var sauceOptions = new Dictionary<string, object>();

            var browserOptions = new ChromeOptions();
            browserOptions.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name, true);
            browserOptions.AddAdditionalCapability("username", AppVariables.GetSAUCELABS_USERNAME(), true);
            browserOptions.AddAdditionalCapability("accessKey", AppVariables.GetSAUCELABS_ACCESSKEY(), true);
            driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), browserOptions);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            return driver;
        }

        [TearDown]
        public void TearDown()
        {
            log.Info("Close Browser instance");
            driver.Close();
            driver.Quit();
        }
    }
}
