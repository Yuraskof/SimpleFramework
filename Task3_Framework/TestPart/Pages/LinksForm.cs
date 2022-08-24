using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class LinksForm:BasePage
    {
        private static Wrapper linksPageWrapper;
        private static string linksPageWrapperName = "\"links page wrapper\"";
        private static By linksFormLocator = By.XPath("//*[@id = \"linkWrapper\"]");
        private static string pageName = "\"links form\"";

        private static By homeReferenceLocator = By.XPath("//*[@id = \"simpleLink\"]");
        private static string homeReferenceName = "\"Home reference\"";
        private static Reference homeReference = new Reference(homeReferenceLocator, homeReferenceName);

        public LinksForm() : base(linksPageWrapper = new Wrapper(linksFormLocator, linksPageWrapperName), pageName)
        {
            locator = linksFormLocator;
            elementName = linksPageWrapperName;
        }


        public void OpenHomeReference()
        {
            homeReference.JsScrollToElement();
            homeReference.Click();
        }
    }
}
