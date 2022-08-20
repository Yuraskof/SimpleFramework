using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Task2_SeleniumWebDriver.Steam.FrameworkPart;

namespace Task3_Framework.TestPart.BaseClasses
{
    public abstract class BaseElement
    {
        protected By uniqueLocator;
        protected string uniqueName;

        public BaseElement(By locator, string name)
        {
            this.uniqueLocator = locator;
            this.uniqueName = name;
        }

        public bool Find(By locator, string name)
        {
            return DriverUtils.WebDriver.FindElements(locator).Count > 0;
            //log
        }

        public void Click(By locator, string name)
        {
            if (Find(locator, name))
            {
                IWebElement element = DriverUtils.WebDriver.FindElement(locator);
                element.Click();
                //log
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
            }
        }
    }
}
