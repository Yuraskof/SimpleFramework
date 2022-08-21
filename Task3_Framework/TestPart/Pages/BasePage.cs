using OpenQA.Selenium;


namespace Task3_Framework.TestPart.BaseClasses
{
    public abstract class BasePage
    {
        protected By uniqueElement;
        protected string name;

        public BasePage()
        {
            
        }

        public BasePage(By locator, string name)
        {
            uniqueElement = locator;
            this.name = name;
        }

        public bool isPageOpen()
        {
            return DriverUtils.WebDriver.FindElements(uniqueElement).Count > 0; 
            // в лог с именем
        }
    }
}
