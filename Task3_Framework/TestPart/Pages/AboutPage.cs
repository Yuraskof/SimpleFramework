using OpenQA.Selenium;
using Task2_SeleniumWebDriver.Steam.FrameworkPart;
using Task2_SeleniumWebDriver.Steam.FrameworkPart.BrowserUtils;

namespace Task2_SeleniumWebDriver.Steam.TestPart.Pages
{
    class AboutPage : BasePage
    {
        private string aboutPageBaseElement = "//div[contains(@class,\"online_stats\")]";
        private string gamersOnline = "//*[@class=\"online_stats\"]//div[div[contains(@class,'gamers_online')]]";
        private string gamersPlaying = "//*[@class=\"online_stats\"]//div[div[contains(@class,'gamers_in_game')]]";

        public bool CheckPageAboutIsOpen()
        {
            var mainPageIsOpenLocator = DriverUtils.WebDriver.FindElements(By.XPath(aboutPageBaseElement));
            return mainPageIsOpenLocator.Count > 0;
        }

        public bool FindElementGamersOnline()
        {
            var elements = DriverUtils.WebDriver.FindElements(By.XPath(gamersOnline));
            return elements.Count > 0;
        }

        public int FindGamersOnlineCount()
        {
            string text = SaveText(gamersOnline);
            var gamersCount = Helpers.ConvertToIntSearchResults(text);
            return gamersCount;
        }

        public bool FindGamersPlayingCountElement()
        {
            return DriverUtils.WebDriver.FindElements(By.XPath(gamersPlaying)).Count > 0;
        }

        public int FindGamersPlayingCount()
        {
            string text = SaveText(gamersPlaying);
            var gamersCount = Helpers.ConvertToIntSearchResults(text);
            return gamersCount;
        }
    }
}
