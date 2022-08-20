//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Text.RegularExpressions;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Support.UI;

//namespace Task2_SeleniumWebDriver.Steam.FrameworkPart.BrowserUtils
//{
//    public static class Helpers
//    {
//        public void ClickElement(string locator)
//        {
//            var element = DriverUtils.WebDriver.FindElement(By.XPath(locator));
//            element.Click();
//        }

//        public void SendKeys(string locator, string text)
//        {
//            DriverUtils.WebDriver.FindElement(By.XPath(locator)).SendKeys(text);
//        }

//        public string SaveText(string locator)
//        {
//            string searchText = DriverUtils.WebDriver.FindElement(By.XPath(locator)).Text;

//            return searchText;
//        }

//        public void SelectFromListOfElementsByText(string locator, string text)
//        {
//            IReadOnlyList<IWebElement> elements = DriverUtils.WebDriver.FindElements(By.XPath(locator));

//            var selectObject = new SelectElement(elements[0]);

//            selectObject.SelectByText(text);
//        }

//        public bool MoveToElement(string locator)
//        {
//            Actions action = new Actions(DriverUtils.WebDriver);
//            IReadOnlyList<IWebElement> elements = GetElementsList(locator);
//            action.MoveToElement(elements[0]);
//            action.Perform();
//            return elements.Count > 0;
//        }

//        public IReadOnlyList<IWebElement> GetElementsList(string locator)
//        {
//            IReadOnlyList<IWebElement> elements = DriverUtils.WebDriver.FindElements(By.XPath(locator));
//            return elements;
//        }

//        public IReadOnlyList<IWebElement> GetElementsList(string locator, WebDriverWait wait)
//        {
//            IReadOnlyList<IWebElement> elements = wait.Until(driver => driver.FindElements(By.XPath(locator)));

//            return elements;
//        }
//    }
//}
