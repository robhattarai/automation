using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDotNetCore.PageObjects
{
    public class SearchPage : TestInit
    {
        /***
         * Page Factory has been deprecated from Selenium 3.6.0
         * [FindsBy(How = How.Id, Using = "searchDropdownBox")]
         * public IWebElement searchCategoryDropDownElement { get; set; }
         ***/

        //public static IWebElement DropDownSearchCategory(IWebDriver driver)
        //{
        //    return driver.FindElement(By.Id("searchDropdownBox"));
        //}

        public static IWebElement DropDownSearchCategory(IWebDriver driver) => driver.FindElement(By.Id("searchDropdownBox"));
        public static IWebElement TextBoxSearch(IWebDriver driver) => driver.FindElement(By.Id("twotabsearchtextbox"));
        public static IWebElement DropDownSortBy(IWebDriver driver) => driver.FindElement(By.Id("a-autoid-0-announce"));
        public static IWebElement DropDownValueAvgCustReview(IWebDriver driver) => driver.FindElement(By.Id("s-result-sort-select_3"));
        public static IWebElement TextBoxMinPrice(IWebDriver driver) => driver.FindElement(By.Id("low-price"));
        public static IWebElement TextBoxMaxPrice(IWebDriver driver) => driver.FindElement(By.Id("high-price"));
        public static IWebElement ButtonGo(IWebDriver driver) => driver.FindElement(By.ClassName("a-button-input"));
    }
}
