using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Task2_SeleniumWebDriver.Steam.FrameworkPart.BrowserUtils
{
    static class BrowserFactory
    {
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
                    return driver;

                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    FirefoxOptions optionsFirefox = new FirefoxOptions();
                    FirefoxProfile firefoxProfile = new FirefoxProfile();
                    firefoxProfile.SetPreference("intl.accept_languages", DriverUtils.BrowserConfig["languageFirefox"]);
                    optionsFirefox.AddArguments(DriverUtils.BrowserConfig["regimeFirefox"]);
                    optionsFirefox.Profile = firefoxProfile;
                    driver = new FirefoxDriver(optionsFirefox);
                    return driver;
                default:
                    throw new Exception("No suitable browser found. Check browser name in config.json.");
            }
        }
    }
}
