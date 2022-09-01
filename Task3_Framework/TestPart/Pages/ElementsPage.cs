using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class ElementsPage:BasePage
    {
        private static Accordion elementsAccordion;
        public MenuPage menuPage = new MenuPage();

        public ElementsPage() : base(elementsAccordion = new Accordion(By.XPath(string.Format("//div[contains(@class, \"show\")]//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["ElementsWindows"])), "\"Elements accordion\""), "\"Elements pagee\"")
        {
        }
    }
}
