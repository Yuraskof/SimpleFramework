using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class ElementsPage:BasePage
    {
        private static Accordion elementsAccordion;
        private static string elementsAccordionName = "\"Elements accordion\"";
        private static By elementsAccordionLocator = By.XPath(string.Format("//div[contains(@class, \"show\")]//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["ElementsWindows"]));
        private static string pageName = "\"Elements pagee\"";
        
        public MenuPage menuPage = new MenuPage();

        public ElementsPage() : base(elementsAccordion = new Accordion(elementsAccordionLocator, elementsAccordionName), pageName)
        {
            locator = elementsAccordionLocator;
            elementName = elementsAccordionName;
        }
    }
}
