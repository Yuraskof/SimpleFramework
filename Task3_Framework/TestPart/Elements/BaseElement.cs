using System.Collections.Generic;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Task3_Framework.TestPart.BaseClasses
{
    public abstract class BaseElement
    {
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected By uniqueLocator;
        protected string uniqueName;

        public BaseElement(By locator, string name)
        {
            this.uniqueLocator = locator;
            this.uniqueName = name;
        }

        protected IWebElement Find(By locator, string name)
        {
            if (DriverUtils.WebDriver.FindElements(locator).Count > 0)
            {
                log.Info(string.Format("element {0} found", name));
                IWebElement element = DriverUtils.WebDriver.FindElements(locator)[0];
                return element;
            }
            log.Info(string.Format("element {0} not found", name));
            return null;
        }

        public void Click(By locator, string name)
        {
            IWebElement element = Find(locator, name);
            element.Click();
            log.Info(string.Format("element {0} clicked", name));
        }
        
        public void JsScrollToElement(By locator, string name)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverUtils.WebDriver;
            IWebElement element = Find(locator, name);
            js.ExecuteScript("arguments[0].scrollIntoView();", element);
            log.Info(string.Format("scrolled to element {0} ", name));
        }

        public string SaveText(By locator, string name)
        {
            string text = Find(locator, name).Text;
            log.Info(string.Format("element {0} text = {1}", name, text));
            return text;
        }

        public bool IsEnabled(By locator, string name)
        {
            bool isEnabled = Find(locator, name).Enabled;
            log.Info(string.Format("element enabled = {0}", isEnabled));
            return isEnabled;
        }

        public bool IsDisplayed(By locator, string name, WebDriverWait wait)
        {
            var element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
            log.Info(string.Format("element is not displayed = {0}", element));
            return element;
        }

        

        //public void MoveToElement(By locator, string name)
        //{
        //    if (Find(locator, name))
        //    {
        //        Actions action = new Actions(DriverUtils.WebDriver);
        //        IWebElement element = DriverUtils.WebDriver.FindElement(locator);
        //        action.MoveToElement(element);
        //        action.Perform();
        //    }
        //}
    }
}
