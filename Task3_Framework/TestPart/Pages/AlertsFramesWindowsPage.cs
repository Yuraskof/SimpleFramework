using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class AlertsFramesWindowsPage :BasePage
    {
        private static Accordion alertsAccordion;
        private static string alertsAccordionName = "\"Alerts accordion\"";
        private static By alertsAccordionLocator = By.XPath(string.Format("//div[contains(@class, \"show\")]//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["AlertsFramesWindows"]));
        private static string pageName = "\"Alerts page\"";
        
        public MenuPage menuPage = new MenuPage();

        public AlertsFramesWindowsPage() : base(alertsAccordion = new Accordion(alertsAccordionLocator, alertsAccordionName), pageName)
        {
            locator = alertsAccordionLocator;
            elementName = alertsAccordionName;
        }
        
    }
}
