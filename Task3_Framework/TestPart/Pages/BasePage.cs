using log4net;

namespace Task3_Framework.TestPart.BaseClasses
{
    public abstract class BasePage
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected BaseElement uniqueElement;
        protected string pageName;

        public BasePage(BaseElement element, string pageName)
        {
            uniqueElement = element;
            this.pageName = pageName;
            log.Info(string.Format("Page {0} created", pageName));
        }

        public bool isPageOpen()
        {
            if (uniqueElement.IsEnabled())
            {
                log.Info(string.Format("Page {0} is open", pageName));
                return true;
            }
            log.Info(string.Format("Page {0} isn't open", pageName));
            return false;
        }
    }
}
