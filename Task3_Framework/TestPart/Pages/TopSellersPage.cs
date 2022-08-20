using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task2_SeleniumWebDriver.Steam.FrameworkPart;
using Task2_SeleniumWebDriver.Steam.FrameworkPart.BrowserUtils;

namespace Task2_SeleniumWebDriver.Steam.TestPart.Pages
{
    class TopSellersPage : BasePage
    {
        private string topSellersPageBaseElement = "//div[@id=\"additional_search_options\"]";

        private string steamCheckBox =
            string.Format("//span[@data-loc = \"{0}\"]//span[@class = \"tab_filter_control_checkbox\"]", TestData["OS"]);

        private string steamCheckBoxPanel = string.Format("//span[@data-loc = \"{0}\"][contains(@class, \"checked\")]", TestData["OS"]);

        private string numberOfPlayersPanel =
            "//div[contains(@class, \"block search_collapse_block\")]//div[contains(text(), \"Narrow by number\")]";

        private string numberOfPlayersCheckBox =
            string.Format("//span[@data-loc = \"{0}\"]//span[@class =\"tab_filter_control_checkbox\"]", TestData["NumberOfPlayers"]);

        private string acceptCookies = "//*[@id= \"acceptAllButton\"]";

        private string numberPlayersPanelChecked =
            string.Format("//span[@data-loc = \"{0}\"][contains(@class, \"checked\")]", TestData["NumberOfPlayers"]);

        private string tagCheckBox =
            string.Format("//*[@id=\"TagFilter_Container\"]//span[@data-loc =\"{0}\" and contains(@class, \"tab_filter_control_include\")]", TestData["Tag"]);

        private string tagPanel = string.Format("//span[@data-loc = \"{0}\"][contains(@class, \"checked\")]", TestData["Tag"]);

        private string gameName =
            string.Format("//div[@id = \"search_resultsRows\"]//a[{0}]//span[@class= \"title\"]", TestData["GameCount"]);

        private string gameReliseDate =
            string.Format(
                "//div[@id = \"search_resultsRows\"]//a[{0}]//div[contains(@class, \"search_released\")]", TestData["GameCount"]);

        private string gamePriceFull =
            string.Format(
                "//div[@id = \"search_resultsRows\"]//a[{0}]//div//div//div[contains(@class, \"search_price\")]", TestData["GameCount"]);

        private string searchResultsCount = "//*[@id=\"search_results\"]//div[@class = \"search_results_count\"]";
        private string searchingTag = "//*[@class=\"searchtag tag_dynamic\"]";
        private string allResultsElement = "//*[@id=\"search_resultsRows\"]//a";
        private string allgameNames = "//div[contains(@class, \"search_name ellipsis\")]//span[@class = \"title\"]";


        private static Dictionary<string, string> TestData = ConfigUtils.GetTestData("TopSellersPageFilter");

        public bool ExplictWaitTopSellersFindElement(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = wait.Until(driver => DriverUtils.WebDriver.FindElements(By.XPath(topSellersPageBaseElement)));
            return elements.Count > 0;
        }

        public bool ExplictWaitFindOSCheckBox(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = wait.Until(driver => DriverUtils.WebDriver.FindElements(By.XPath(steamCheckBox)));
            return elements.Count > 0;
        }

        public void ClickCheckBoxOS()
        {
            ClickElement(steamCheckBox);
        }

        public bool ExplictWaitFindSteamPanel(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = wait.Until(driver => DriverUtils.WebDriver.FindElements(By.XPath(steamCheckBoxPanel)));
            return elements.Count > 0;
        }

        public bool ExplictWaitFindNumberOfPlayersPanel(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = wait.Until(driver => DriverUtils.WebDriver.FindElements(By.XPath(numberOfPlayersPanel)));
            return elements.Count > 0;
        }

        public void ClickCheckNumberOfPlayersPanel()
        {
            ClickElement(numberOfPlayersPanel);
        }

        public bool ExplictWaitFindNumberOfPlayersCheckBox(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = wait.Until(driver => DriverUtils.WebDriver.FindElements(By.XPath(numberOfPlayersCheckBox)));
            return elements.Count > 0;
        }

        public bool ExplictWaitFindVisibleCookiesAcceptElement(WebDriverWait wait)
        {
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(acceptCookies)));
            return element != null;
        }

        public void ClickCookiesAcceptElement()
        {
            ClickElement(acceptCookies);
        }

        public void ClickNumberOfPlayersCheckBox()
        {
            ClickElement(numberOfPlayersCheckBox);
        }

        public bool ExplictWaitFindCheckedPlayersPanel(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = wait.Until(driver => DriverUtils.WebDriver.FindElements(By.XPath(numberPlayersPanelChecked)));
            return elements.Count > 0;
        }

        public bool ExplictWaitFindTagCheckBox(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = wait.Until(driver => DriverUtils.WebDriver.FindElements(By.XPath(tagCheckBox)));
            return elements.Count > 0;
        }

        public void ClickTagCheckBox()
        {
            ClickElement(tagCheckBox);
        }

        public bool ExplictWaitFindCheckedTagCheckBox(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = wait.Until(driver => DriverUtils.WebDriver.FindElements(By.XPath(tagPanel)));
            return elements.Count > 0;
        }

        public bool ExplictWaitFindVisibleTag(WebDriverWait wait)
        {
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(searchingTag)));
            return element != null;
        }

        public bool ExplictWaitFindVisibleSearchResults(WebDriverWait wait)
        {
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(searchResultsCount)));
            return element != null;
        }

        public int ConvertToIntSearchResults()
        {
            string searchText = SaveText(searchResultsCount);
            int convertedValue = Helpers.ConvertToIntSearchResults(searchText);
            return convertedValue;
        }

        public int ExplictWaitFindAllSearchResults(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = wait.Until(driver => DriverUtils.WebDriver.FindElements(By.XPath(allResultsElement)));
            return elements.Count;
        }

        public bool ExplictWaitFindVisibleGameName(WebDriverWait wait)
        {
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(gameName)));
            return element != null;
        }

        public string SaveGameName()
        {
            string text = SaveText(gameName);
            return text;
        }

        public bool ExplictWaitFindGameReleaseDate(WebDriverWait wait)
        {
            var elements = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(gameReliseDate)));
            return elements != null; 
        }

        public string SaveGameReleaseDate()
        {
            string text = SaveText(gameReliseDate);
            return text;
        }

        public bool ExplictWaitFindGamePrice(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = wait.Until(driver => DriverUtils.WebDriver.FindElements(By.XPath(gamePriceFull)));
            return elements.Count > 0;
        }

        public List<decimal> GetPricesList()
        {
            string gameFullPriceString = SaveText(gamePriceFull);

            List<decimal> gamePrices = new List<decimal>();

            gamePrices = Helpers.ParsePrices(gameFullPriceString);
            return gamePrices;
        }

        
        public bool ExplictWaitFindAllGamesElement(WebDriverWait wait)
        {
            var elements = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(allgameNames)));
            return elements != null;
        }

        public void ClickGameName(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = GetElementsList(allgameNames, wait); 
            elements[Convert.ToInt32(TestData["GameCount"]) - 1].Click();
        }
    }
}


