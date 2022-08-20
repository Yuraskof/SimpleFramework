using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Task2_SeleniumWebDriver.Steam.FrameworkPart.BrowserUtils;


namespace Task2_SeleniumWebDriver.Steam.FrameworkPart
{
    public static class DriverUtils
    {
        public static Dictionary<string, string> BrowserConfig = new Dictionary<string, string>();

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
            }

            return _driver;
        }

        public static void SetImplicitWait(int seconds)
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public static void ResetDriver()
        {
            WebDriver = null;
            BrowserConfig.Clear();
        }
    }
}
