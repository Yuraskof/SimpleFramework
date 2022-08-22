using log4net;
using OpenQA.Selenium;


namespace Task3_Framework.TestPart.BaseClasses
{
    public abstract class BasePage
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected By uniqueElement;
        protected string name;

        public BasePage()
        {
            
        }

        public BasePage(By locator, string name)
        {
            uniqueElement = locator;
            this.name = name;
            log.Info(string.Format("Page {0} created", name));
        }

        public bool isPageOpen()
        {
            if (DriverUtils.WebDriver.FindElements(uniqueElement).Count > 0)
            {
                log.Info(string.Format("Page {0} is open", name)); 
                return true;
            }

            log.Info(string.Format("Page {0} isn't open", name));
            return false;
        }
    }
}
