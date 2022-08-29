using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class WidgetsPage : BasePage
    {
        private static Accordion widgetsAccordion;
        private static string widgetsAccordionName = "\"Widgets accordion\"";
        private static By widgetsAccordionLocator = By.XPath(string.Format("//div[contains(text(), \"{0}\")]//following:: div[contains(@class, \"show\")]", ConfigUtils.TestData["WidgetsWindows"]));
        private static string pageName = "\"Widgets page\"";

        public MenuPage menuPage = new MenuPage();

        public WidgetsPage() : base(widgetsAccordion = new Accordion(widgetsAccordionLocator, widgetsAccordionName), pageName)
        {
            locator = widgetsAccordionLocator;
            elementName = widgetsAccordionName;
        }
    }
}