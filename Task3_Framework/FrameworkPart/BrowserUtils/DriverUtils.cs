﻿using System;
using System.Collections.Generic;
using log4net;
using OpenQA.Selenium;


namespace Task3_Framework
{
    public static class DriverUtils
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
            log.Info(string.Format("implicit wait = {0} sec", seconds));
        }

        public static void ResetDriver()
        {
            WebDriver = null;
            BrowserConfig.Clear();
            log.Info("driver reset");
        }
    }
}
