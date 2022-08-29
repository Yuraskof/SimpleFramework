using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class WidgetsPage : BasePage
    {
        private static Accordion widgetsAccordion;

        public MenuPage menuPage = new MenuPage();

        public WidgetsPage() : base(widgetsAccordion = new Accordion(By.XPath(string.Format("//div[contains(text(), \"{0}\")]//following:: div[contains(@class, \"show\")]", ConfigUtils.TestData["WidgetsWindows"])), "\"Widgets accordion\""), "\"Widgets page\"")
        {
            locator = By.XPath(string.Format("//div[contains(text(), \"{0}\")]//following:: div[contains(@class, \"show\")]", ConfigUtils.TestData["WidgetsWindows"]));
            elementName = "\"Widgets accordion\"";
        }
    }
}