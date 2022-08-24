using log4net;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace Task3_Framework.FrameworkPart.UtilClasses
{
    class BrowserUtils
    {
        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

        public static bool AlertIsClosed(WebDriverWait wait)
        {
            if (wait.Until(ExpectedConditions.AlertState(false)))
            {
                log.Info("alert isn't present");
                return true;
            }

            log.Info("alert is present");
            return false;
        }

        public static string GetTextFromAlert(WebDriverWait wait)
        {
            IAlert alert = DriverUtils.WebDriver.SwitchTo().Alert();
            string text = alert.Text;
            log.Info(string.Format("alert text = {0}", text));
            return text;
        }

        public static void AcceptAlert(WebDriverWait wait)
        {
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
            log.Info("alert accepted");
        }

        public static void DismissAlert(WebDriverWait wait)
        {
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Dismiss();
            log.Info("alert declined");
        }

        public static void AlertSendKeys(string text, WebDriverWait wait)
        {
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
            alert.SendKeys(text);
            log.Info(string.Format("entered text = {0}", text));
        }

        public static void SwitchToFrame(By locator, string name)
        {
            IWebElement iframe = DriverUtils.WebDriver.FindElement(locator);
            DriverUtils.WebDriver.SwitchTo().Frame(iframe);
            log.Info(string.Format("switched to {0} ", name));
        }

        public static void SwitchToTopLevel()
        {
            DriverUtils.WebDriver.SwitchTo().DefaultContent();
            log.Info("returned to the top level");
        }


        public static string SaveCurrentWindowHandle()
        {
            string originalWindow = DriverUtils.WebDriver.CurrentWindowHandle;
            log.Info(string.Format("Current window handle = {0}", originalWindow));
            return originalWindow;
        }

        public static void SwitchToNextTab(string originalWindow, int windowsCount, WebDriverWait wait)
        {
            wait.Until(wd => wd.WindowHandles.Count == windowsCount);

            foreach (string window in DriverUtils.WebDriver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    DriverUtils.WebDriver.SwitchTo().Window(window);
                    log.Info(string.Format("Switched to next tab = {0}", window));
                    break;
                }
            }
        }

        public static string GetUrl()
        {
            string url = DriverUtils.WebDriver.Url;
            log.Info(string.Format("Current window url = {0}", url));
            return url;
        }

        public static void CloseTab()
        {
            DriverUtils.WebDriver.Close();
            log.Info("window closed");
        }

        public static void SwitchHandleBack(string window)
        {
            DriverUtils.WebDriver.SwitchTo().Window(window);
            log.Info(string.Format("returned to  handle = {0}", window));

        }
    }
}
