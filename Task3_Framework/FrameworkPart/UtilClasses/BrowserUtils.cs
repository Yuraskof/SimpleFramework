using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using Task2_SeleniumWebDriver.Steam.FrameworkPart;

namespace Task3_Framework.FrameworkPart.UtilClasses
{
    class BrowserUtils
    {
        public static void GoToUrl(string url)
        {
            DriverUtils.WebDriver.Url = url;
        }

        public static bool AlertIsPresent(WebDriverWait wait)
        {
            return  wait.Until(ExpectedConditions.AlertIsPresent()) != null;
        }

        public static string GetTextFromAlert(WebDriverWait wait)
        {
            IAlert alert = DriverUtils.WebDriver.SwitchTo().Alert();
            string text = alert.Text;
            return text;
        }

    }
}
