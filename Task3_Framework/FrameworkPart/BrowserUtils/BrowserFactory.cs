﻿using System;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Task3_Framework
{
    static class BrowserFactory
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static IWebDriver CreateDriver(string browserName)
        {
            IWebDriver driver = null;

            switch (browserName)
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    ChromeOptions optionsChrome = new ChromeOptions();
                    optionsChrome.AddArguments(DriverUtils.BrowserConfig["optionsChrome"]);
                    driver = new ChromeDriver(optionsChrome);
                    log.Info(string.Format("browser = {0}", browserName));
                    return driver;

                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    FirefoxOptions optionsFirefox = new FirefoxOptions();
                    FirefoxProfile firefoxProfile = new FirefoxProfile();
                    firefoxProfile.SetPreference("intl.accept_languages", DriverUtils.BrowserConfig["languageFirefox"]);
                    optionsFirefox.AddArguments(DriverUtils.BrowserConfig["regimeFirefox"]);
                    optionsFirefox.Profile = firefoxProfile;
                    driver = new FirefoxDriver(optionsFirefox);
                    log.Info(string.Format("browser = {0}", browserName));
                    return driver;
                default:
                    throw new Exception("No suitable browser found. Check browser name in config.json.");
            }
        }
    }
}
