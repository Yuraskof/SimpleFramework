using log4net;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace Task3_Framework.FrameworkPart.UtilClasses
{
    class BrowserUtils
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void GoToUrl(string url)
        {
            DriverUtils.WebDriver.Url = url;
            log.Info(string.Format("open url = {0}", url));
        }

        public static bool AlertIsPresent(WebDriverWait wait)
        {
            if (wait.Until(ExpectedConditions.AlertIsPresent()) != null)
            {
                log.Info("alert is present");
                return true;
            }

            log.Info("alert isn't present");
            return false;
        }

        public static string GetTextFromAlert(WebDriverWait wait)
        {
            IAlert alert = DriverUtils.WebDriver.SwitchTo().Alert();
            string text = alert.Text;
            log.Info(string.Format("alert text = {0}", text));
            return text;
        }

    }
}
