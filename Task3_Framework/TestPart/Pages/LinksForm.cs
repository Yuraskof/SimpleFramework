using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class LinksForm:BasePage
    {
        private static Wrapper linksPageWrapper;
        private static Reference homeReference = new Reference(By.XPath("//*[@id = \"simpleLink\"]"), "\"Home reference\"");

        public LinksForm() : base(linksPageWrapper = new Wrapper(By.XPath("//*[@id = \"linkWrapper\"]"), "\"links page wrapper\""), "\"links form\"")
        {
            locator = By.XPath("//*[@id = \"linkWrapper\"]");
            elementName = "\"links page wrapper\"";
        }
        
        public void OpenHomeReference()
        {
            homeReference.JsScrollToElement();
            homeReference.Click();
        }
    }
}
