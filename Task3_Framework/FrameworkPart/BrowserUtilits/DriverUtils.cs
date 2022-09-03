using System;
using System.Collections.Generic;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Task3_Framework
{
    public static class DriverUtils
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static Dictionary<string, string> BrowserConfig = new Dictionary<string, string>();

        public static WebDriverWait wait;

        private static IWebDriver _driver;

        public static IWebDriver WebDriver
        {
            get
            {
                return _driver;
            }
            private set
            {
                _driver = value;
            } 
        }

        public static IWebDriver getInstance()
        {
            if (_driver == null)
            {
                WebDriver = BrowserFactory.CreateDriver(BrowserConfig["browser"]);
                SetImplicitWait(Convert.ToInt32(BrowserConfig["wait_time"]));
                SetExplicitWait(Convert.ToInt32(BrowserConfig["wait_time"]));
            }

            return _driver;
        }

        public static void SetExplicitWait(int seconds)
        {
            log.Info(string.Format("explicit wait = {0} sec", seconds));
            wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(seconds));
        }

        public static void SetImplicitWait(int seconds)
        {
            log.Info(string.Format("implicit wait = {0} sec", seconds));
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public static void ResetDriver()
        {
            log.Info("driver reset");
            WebDriver = null;
            BrowserConfig.Clear();
        }
    }
}
