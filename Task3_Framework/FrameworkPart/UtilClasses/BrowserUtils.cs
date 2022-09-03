using System;
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
            log.Info(string.Format("open url = {0}", url));
            DriverUtils.WebDriver.Url = url;
        }

        public static bool AlertIsPresent()
        {
            try
            {
                log.Info("Alert is present");
                IAlert alert = DriverUtils.WebDriver.SwitchTo().Alert();
                return true;
            }
            catch (Exception e)
            {
                log.Info("Alert not found");
                return false;
            }
        }

        public static IAlert SwitchToAlert()
        {
            log.Info("Switched to alert");
            IAlert alert = DriverUtils.WebDriver.SwitchTo().Alert();
            return alert;
        }

        public static string GetTextFromAlert()
        {
            string text = SwitchToAlert().Text;
            log.Info(string.Format("alert text = {0}", text));
            return text;
        }

        public static void AcceptAlert(WebDriverWait wait)
        {
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
            log.Info("alert accepted");
            alert.Accept();
        }

        public static void AlertSendKeys(string text, WebDriverWait wait)
        {
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
            log.Info(string.Format("entered text = {0}", text));
            alert.SendKeys(text);
        }

        public static void SwitchToFrame(By locator, string name)
        {
            IWebElement iframe = DriverUtils.WebDriver.FindElement(locator);
            log.Info(string.Format("switched to {0} ", name));
            DriverUtils.WebDriver.SwitchTo().Frame(iframe);
        }

        public static void SwitchToTopLevel()
        {
            log.Info("returned to the top level");
            DriverUtils.WebDriver.SwitchTo().DefaultContent();
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
                    log.Info(string.Format("Switched to next tab = {0}", window));
                    DriverUtils.WebDriver.SwitchTo().Window(window);
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
            log.Info("window closed");
            DriverUtils.WebDriver.Close();
        }

        public static void SwitchHandleBack(string window)
        {
            log.Info(string.Format("returned to  handle = {0}", window));
            DriverUtils.WebDriver.SwitchTo().Window(window);
        }

        public static void ScrollScrypt(By locator, string name)
        {
            log.Info(string.Format("scrolled to element {0} ", name));
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverUtils.WebDriver;
            IWebElement element = DriverUtils.WebDriver.FindElement(locator);
            js.ExecuteScript("arguments[0].scrollIntoView();", element);
        }
    }
}
