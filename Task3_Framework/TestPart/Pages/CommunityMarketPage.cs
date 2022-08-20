using System.Collections.Generic;
using OpenQA.Selenium;
using Task2_SeleniumWebDriver.Steam.FrameworkPart;
using Task2_SeleniumWebDriver.Steam.FrameworkPart.BrowserUtils;

namespace Task2_SeleniumWebDriver.Steam.TestPart.Pages
{
    class CommunityMarketPage:BasePage
    {
        private string commMarketBaseElement = "//*[@class=\"market_search_sidebar_contents\"]";
        private string searchAdvancedButton = "//*[@class=\"market_search_advanced_button\"]";
        private string filters = "//*[@class=\"market_search_results_header\"]//div//a";
        private string namesInSearchResults = "//div[@id = \"searchResultsRows\"]//span[@class = \"market_listing_item_name\"]";

        public static Dictionary<string, string> TestDataCommunityMarket = ConfigUtils.GetTestData("CommunityMarketPage");

        public SearchMenuComMarketPage searchMenu = new SearchMenuComMarketPage();

        public bool CheckCommunityMarketPageIsOpen()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(commMarketBaseElement));
            return elements.Count > 0;
        }

        public bool FindAdvancedSearchButton()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(searchAdvancedButton));
            return elements.Count > 0;
        }

        public void ClickAdvancedSearchButton()
        {
            ClickElement(searchAdvancedButton);
        }

        public bool FindFiltersElement()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(filters));
            return elements.Count > 0;
        }

        public List<string> GetFiltersNames()
        {
            IReadOnlyList<IWebElement> filterElements = GetElementsList(filters);

            List<string> parcedText = Helpers.GetTextFromFilterElements(filterElements);
            return parcedText;
        }

        public IReadOnlyList<IWebElement> GetFilterNamesElements()
        {
            IReadOnlyList<IWebElement> elements = GetElementsList(filters);
            return elements;
        }

        public bool FindAllNamesElement()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(namesInSearchResults));
            return elements.Count > 0;
        }

        public IReadOnlyList<IWebElement> GetNamesElements()
        {
            IReadOnlyList<IWebElement> elements = GetElementsList(namesInSearchResults);
            return elements;
        }
    }
}
