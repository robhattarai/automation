using NUnit.Framework;
using SeleniumDotNetFramework.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace SeleniumDotNetFramework.Tests
{
    class TestAmazonSearchProduct : TestInit
    {
        string searchText = "calculator";

        [Test]
        public void AmazonSearch()
        {
            log.Info("Test Case: Search Calculator in Amazon sorted by Avg. Customer Review within price range ");

            log.Info("Step 1: Change the search type to Electronics");
            SearchPage.DropDownSearchCategory(driver).Click();
            SelectElement searchCategoryDropDown = new SelectElement(SearchPage.DropDownSearchCategory(driver));
            searchCategoryDropDown.SelectByText("Electronics");

            log.Info("Step 2: Enter the search term \"calculators\"");
            SearchPage.TextBoxSearch(driver).Clear();
            SearchPage.TextBoxSearch(driver).SendKeys(searchText);
//            searchPage.searchTextBox.SendKeys(searchText + "\n" + Keys.Enter);

            log.Info("Step 3: click the Seach icon");
            SearchPage.TextBoxSearch(driver).Submit();

            log.Info("Step 4: Sort the results by \"Average Customer Review\"");
            SearchPage.DropDownSortBy(driver).Click();
            SearchPage.DropDownValueAvgCustReview(driver).Click();

            log.Info("Step 5: Filter results to only show calculators in the range of $300 to $350");
            SearchPage.TextBoxMinPrice(driver).SendKeys("300");
            SearchPage.TextBoxMaxPrice(driver).SendKeys("350");
            SearchPage.ButtonGo(driver).Click();

            log.Info("Step 6: Save all the search results into a List of WebElements");
            log.Info("Search Results Page should show: " + SearchResultsPage.LabelResultCountSummary(driver).Text);
            Assert.That(SearchResultsPage.LabelResultCountSummary(driver).Text.Contains("Electronics : $300-$350 : \"calculator\""));

            log.Info("Step 7: Use a for-each loop to assert that each result title contains the word \"calculator\"");
            List<IWebElement> resultTitles = SearchResultsPage.LabelSearchResultTitles(driver);
            foreach (IWebElement resultTitle in resultTitles)
            {
                log.Info(resultTitle.Text);
                Assert.That(resultTitle.Text.ToLower().Contains(searchText.ToLower()));
            }

            log.Info("End Test Case");
        }
    }
}
