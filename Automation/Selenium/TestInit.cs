using NUnit.Framework;
using log4net;
using log4net.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium;

namespace Selenium
{
    [TestFixture]
    public class TestInit
    {
        public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IWebDriver driver;
        protected AppVariables appVar;

        private string URL = "https://www.amazon.com/";

        [SetUp]
        public void SetUp()
        {
            XmlConfigurator.Configure();
            appVar = new AppVariables();
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            log.Info("Open Browser and Navigate URL: " + URL);
            driver.Url = appVar.GetURL();
        }

        [TearDown]
        public void TearDown()
        {
            log.Info("Close Browser instance");
            driver.Close();
        }
    }
}
