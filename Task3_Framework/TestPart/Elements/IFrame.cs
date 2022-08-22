using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;

namespace Task3_Framework.TestPart.Elements
{
    class IFrame:BaseElement
    {
        public IFrame(By locator, string name) : base(locator, name)
        {

        }

        public void SwitchToFrame(By locator, string name)
        {
            IWebElement iframe = Find(locator, name);
            DriverUtils.WebDriver.SwitchTo().Frame(iframe);
            log.Info(string.Format("switched to {0} ", name));
        }

        public void SwitchToTopLevel()
        {
            DriverUtils.WebDriver.SwitchTo().DefaultContent();
            log.Info("returned to the top level");
        }
    }
}
