using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task2_SeleniumWebDriver.Steam.FrameworkPart;
using Task2_SeleniumWebDriver.Steam.FrameworkPart.BrowserUtils;

namespace Task2_SeleniumWebDriver.Steam.TestPart.Pages
{
    class MenuMainPage : BasePage
    {
        private string aboutElement = "//a[@class=\"menuitem\"][contains(text(), \"ABOUT\")]";
        private string buttonStore = string.Format("//a[contains(@class,\"menuitem\")][contains(text(), \"{0}\")]", TestData["button"]);
        private string menuElement = "//div[@id=\"noteworthy_tab\"]//a[@class = \"pulldown_desktop\"]";
        private string popUpLocator = "//*[@id=\"noteworthy_flyout\"]//div[contains(@class, \"popup_menu_browse\")]";
        private string topSellersLocator = "//*[@id=\"noteworthy_flyout\"]//div[contains(@class, \"popup_menu_browse\")]//a[contains(text(), 'Top Sellers')] ";
        private string communityElem = "//a[contains(@class,\"menuitem\")][contains(text(), \"COMMUNITY\")]";
        private string communityMarketElem = "//*[@class=\"supernav_content\"]//a[@class=\"submenuitem\"][contains(text(), 'Market')]";

        private static Dictionary<string, string> TestData = ConfigUtils.GetTestData("AboutPage");

        public bool FindElementAbout()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(aboutElement));
            return elements.Count > 0;
        }

        public void ClickElementAbout()
        {
            ClickElement(aboutElement);
        }

        public bool FindElementStore()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(buttonStore));
            return elements.Count > 0;
        }

        public void ClickElementStore()
        {
            ClickElement(buttonStore);
        }

        public bool MoveToMenuElement()
        {
            return MoveToElement(menuElement);
        }

        public bool ExplictWaitFindVisiblePopUpElement(WebDriverWait wait)
        {
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(popUpLocator)));
            return element != null;
        }

        public int ExplictWaitTopSellersFindElement(WebDriverWait wait)
        {
            IReadOnlyList<IWebElement> elements = wait.Until(driver => driver.FindElements(By.XPath(topSellersLocator)));
            return elements.Count;
        }

        public void ClickElementTopSellers()
        {
            ClickElement(topSellersLocator);
        }

        public bool FindElementCommunity()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(communityElem));
            return elements.Count > 0;
        }

        public bool MoveToCommunityElement()
        {
            return MoveToElement(communityElem);
        }

        public bool FindElementMarket()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(communityMarketElem));
            return elements.Count > 0;
        }

        public void ClickElementMarket()
        {
            ClickElement(communityMarketElem);
        }
    }
}
