using OpenQA.Selenium;
using System.Collections.Generic;

namespace SeleniumDotNetCore.PageObjects
{
    class SearchResultsPage
    {
        public static IWebElement LabelResultCountSummary (IWebDriver driver) => driver.FindElement(By.ClassName("sg-col-inner"));

        public static List<IWebElement> LabelSearchResultTitles(IWebDriver driver)
        {
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.CssSelector("h2 a span"));
            List<IWebElement> resultTitles = new List<IWebElement>(elements);
            return resultTitles;
        }
    }
}
