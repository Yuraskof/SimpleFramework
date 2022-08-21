using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Task3_Framework.TestPart.BaseClasses
{
    public abstract class BaseElement
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected By uniqueLocator;
        protected string uniqueName;

        public BaseElement(By locator, string name)
        {
            this.uniqueLocator = locator;
            this.uniqueName = name;
        }

        public bool Find(By locator, string name)
        {
            if (DriverUtils.WebDriver.FindElements(locator).Count > 0)
            {
                log.Info(string.Format("element {0} found", name));
                return true;
            }
           
            log.Info(string.Format("element {0} not found", name));
            return false;
        }

        public void Click(By locator, string name)
        {
            if (Find(locator, name))
            {
                IWebElement element = DriverUtils.WebDriver.FindElement(locator);
                element.Click();
                log.Info(string.Format("element {0} clicked", name));
            }
        }

        public void MoveToElement(By locator, string name)
        {
            if (Find(locator, name))
            {
                Actions action = new Actions(DriverUtils.WebDriver);
                IWebElement element = DriverUtils.WebDriver.FindElement(locator);
                action.MoveToElement(element);
                action.Perform();
            }
        }

        public void JsScrollToElement(By locator, string name)
        {
            if (Find(locator, name))
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)DriverUtils.WebDriver;
                IWebElement element = DriverUtils.WebDriver.FindElement(locator);
                js.ExecuteScript("arguments[0].scrollIntoView();", element);  //("window.scrollBy(0,250)", "");
                log.Info(string.Format("scrolled to element {0} ", name));
            }
        }
    }
}
