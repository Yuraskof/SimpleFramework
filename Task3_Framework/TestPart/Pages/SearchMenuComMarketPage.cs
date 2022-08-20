using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Task2_SeleniumWebDriver.Steam.FrameworkPart;
using Task2_SeleniumWebDriver.Steam.FrameworkPart.BrowserUtils;

namespace Task2_SeleniumWebDriver.Steam.TestPart.Pages
{
    class SearchMenuComMarketPage : BasePage
    {
        private string searchFormBaseElement = "//div[@class = \"newmodal_header\"]//div[@class=\"title_text\"]";
        private string allGamesElement = "//*[@id = \"market_advancedsearch_appselect_options_apps\"]//div";
        private string expandGameList = "//div[@id= \"app_option_0_selected\"]";
        private string heroList = "//div[@class= \"econ_tag_filter_category\"]//select[@name = \"category_570_Hero[]\"]";
        private string rarityCheckBox = string.Format("//*[@id = \"tag_570_Rarity_Rarity_{0}\"]", TestDataSearchMenu["Rarity"]);
        private string searchField = "//*[@id = \"market_advancedsearch_left\"]//input[@class = \"filter_search_box market_search_sidebar_search_box\"]";
        private string searchButton = "//*[@class = \"market_advancedsearch_bottombuttons\"]//span[contains(text(), \"Search\")]";
        private string acceptCookies = "//*[@id= \"acceptAllButton\"]";

        public static Dictionary<string, string> TestDataSearchMenu = ConfigUtils.GetTestData("SearchMenuCommunMarktPageFilter");


        public bool CheckSearchFormIsOpen()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(searchFormBaseElement));
            return elements.Count > 0;
        }

        public bool FindExpandListElement()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(expandGameList));
            return elements.Count > 0;
        }

        public void ClickExpandListElement()
        {
            ClickElement(expandGameList);
        }

        public bool FindAllGamesElement()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(allGamesElement));
            return elements.Count > 0;
        }

        public void SelectGame()
        {
            IReadOnlyList<IWebElement> gameElements = GetElementsList(allGamesElement);

            for (int i = 0; i < gameElements.Count; i++)
            {
                String textInElement = gameElements[i].Text;

                if (textInElement.Contains(TestDataSearchMenu["Game"]))
                {
                    gameElements[i].Click();
                    break;
                }
            }
        }
        
        public bool FindAllHeroListElement()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(heroList));
            return elements.Count > 0;
        }

        public void ClickHeroListElement()
        {
            ClickElement(heroList);
        }

        public void SelectHero()
        {
            SelectFromListOfElementsByText(heroList, TestDataSearchMenu["Hero"]);
        }

        public bool FindRarityElement()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(rarityCheckBox));
            return elements.Count > 0;
        }

        public void ClickRarityElement()
        {
            ClickElement(rarityCheckBox);
        }

        public bool FindSearchFieldElement()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(searchField));
            return elements.Count > 0;
        }

        public void SearchText()
        {
            SendKeys(searchField, TestDataSearchMenu["Search"]);
        }

        public void AcceptCookies()
        {
            if (FindCookiesElement() && GetElementsList(acceptCookies)[0].Displayed)
            {
                ClickElement(acceptCookies);
            }
        }
        
        public bool FindCookiesElement()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(acceptCookies));
            return elements.Count > 0;
        }

        public bool FindSearchButton()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(searchButton));
            return elements.Count > 0;
        }

        public void ClickSearchButton()
        {
            ClickElement(searchButton);
        }
    }
}
