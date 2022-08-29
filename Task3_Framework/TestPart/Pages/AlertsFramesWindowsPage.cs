using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class AlertsFramesWindowsPage :BasePage
    {
        private static Accordion alertsAccordion;

        public MenuPage menuPage = new MenuPage();

        public AlertsFramesWindowsPage() : base(alertsAccordion = new Accordion(By.XPath(string.Format("//div[contains(@class, \"show\")]//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["AlertsFramesWindows"])), "\"Alerts accordion\""), "\"Alerts page\"")
        {
            locator = By.XPath(string.Format("//div[contains(@class, \"show\")]//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["AlertsFramesWindows"]));
            elementName = "\"Alerts accordion\"";
        }
    }
}
