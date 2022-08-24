using log4net;
using OpenQA.Selenium;


namespace Task3_Framework.TestPart.BaseClasses
{
    public abstract class BasePage
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected BaseElement uniqueElement;
        protected string elementName;
        protected By locator;
        protected string pageName;

        public BasePage()
        {
            
        }

        public BasePage(BaseElement element, string pageName)
        {
            uniqueElement = element;
            this.pageName = pageName;
            log.Info(string.Format("Page {0} created", pageName));
        }

        public bool isPageOpen()
        {
            if (uniqueElement.IsEnabled(locator, elementName))
            {
                log.Info(string.Format("Page {0} is open", pageName));
                return true;
            }
            log.Info(string.Format("Page {0} isn't open", pageName));
            return false;
        }
    }
}
