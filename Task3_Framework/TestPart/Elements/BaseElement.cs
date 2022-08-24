using log4net;
using OpenQA.Selenium;
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

        protected IWebElement Find()
        {
            if (DriverUtils.WebDriver.FindElements(uniqueLocator).Count > 0)
            {
                log.Info(string.Format("element {0} found", uniqueName));
                IWebElement element = DriverUtils.WebDriver.FindElements(uniqueLocator)[0];
                return element;
            }
            log.Error(string.Format("element {0} not found", uniqueName));
            return null;
        }

        public void Click()
        {
            IWebElement element = Find();
            element.Click();
            log.Info(string.Format("element {0} clicked", uniqueName));
        }
        
        public void JsScrollToElement()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverUtils.WebDriver;
            IWebElement element = Find();
            js.ExecuteScript("arguments[0].scrollIntoView();", element);
            log.Info(string.Format("scrolled to element {0} ", uniqueName));
        }

        public string SaveText()
        {
            string text = Find().Text;
            log.Info(string.Format("element {0} text = {1}", uniqueName, text));
            return text;
        }

        public bool IsEnabled()
        {
            bool isEnabled = Find().Enabled;
            log.Info(string.Format("element {1} enabled = {0}", isEnabled, uniqueName));
            return isEnabled;
        }

        public bool IsDisplayed()
        {
            var element = DriverUtils.wait.Until(ExpectedConditions.InvisibilityOfElementLocated(uniqueLocator));
            log.Info(string.Format("element is not displayed = {0}", element));
            return element;
        }
    }
}
