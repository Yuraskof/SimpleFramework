using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task2_SeleniumWebDriver.Steam.FrameworkPart;
using Task2_SeleniumWebDriver.Steam.FrameworkPart.BrowserUtils;

namespace Task2_SeleniumWebDriver.Steam.TestPart.Pages
{
    class GamePage:BasePage
    {
        private string gamePageBaseElement = "//div[contains(@class, \"game_title_area\")]";
        private string gameName = "//div[@id = \"appHubAppName\"]";
        private string gameReliseDate = "//div[@class = \"date\"]";
        private string ifDiscounted = "//div[@class = \"game_purchase_action_bg\"]//div[@class = \"discount_original_price\"]";
        private string gameDiscountPrice = "//div[@class = \"game_purchase_action_bg\"]//div[@class = \"discount_final_price\"]";
        private string gamePriceFull = "//div[contains(@class, \"game_purchase_price\")]";
        

        public bool ExplictWaitFindGamePageBaseElement(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = wait.Until(driver => DriverUtils.WebDriver.FindElements(By.XPath(gamePageBaseElement)));
            return elements.Count > 0;
        }


        public bool ExplictWaitFindGameName(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = wait.Until(driver => DriverUtils.WebDriver.FindElements(By.XPath(gameName)));
            return elements.Count > 0;
        }

        public string SaveGameName()
        {
            String text = SaveText(gameName);
            return text;
        }

        public bool ExplictWaitFindGameReleaseDate(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = wait.Until(driver => DriverUtils.WebDriver.FindElements(By.XPath(gameReliseDate)));
            return elements.Count > 0;
        }

        public string SaveGameReleaseDate()
        {
            String searchText = SaveText(gameReliseDate);
            return searchText;
        }

        public bool IsDiscounted(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = wait.Until(driver => DriverUtils.WebDriver.FindElements(By.XPath(ifDiscounted)));
            return elements.Count > 0;
        }

        public bool ExplictWaitFindDiscountedPriceElement(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = wait.Until(driver => DriverUtils.WebDriver.FindElements(By.XPath(gameDiscountPrice)));
            return elements.Count > 0;
        }
        
        public List<decimal> GetPricesList()
        {
            string gameFullPrice = SaveText(ifDiscounted);
            string gameDiscountedPrice = SaveText(gameDiscountPrice);

            List<decimal> gamePrices = new List<decimal>();

            gamePrices = Helpers.ParsePrices(gameFullPrice + gameDiscountedPrice);

            return gamePrices;
        }

        public bool ExplictWaitFindFullPriceElement(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = wait.Until(driver => DriverUtils.WebDriver.FindElements(By.XPath(gamePriceFull)));
            return elements.Count > 0;
        }

        public decimal GetFullPrice()
        {
            string gameFullPriceString = SaveText(gamePriceFull);
            var gamePrice = Helpers.ParsePrices(gameFullPriceString);
            decimal gameFullPrice = gamePrice[0];
            return gameFullPrice;
        }
    }
}
