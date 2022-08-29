using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class BrowserWindowsForm:BasePage
    {
        private static Button browserWindowsFormButton;
        
        private static By newTabButtonLocator = By.XPath("//*[@id= \"tabButton\"]");
        private static string newTabButtonName = "\"New tab button\"";
        private static Button newTabButton = new Button(newTabButtonLocator, newTabButtonName);

        public BrowserWindowsForm() : base(browserWindowsFormButton = new Button(By.XPath("//*[@id= \"tabButton\"]"), "\"Browser windows form button\""), "\"Browser windows form\"")
        {
            locator = By.XPath("//*[@id= \"tabButton\"]");
            elementName = "\"Browser windows form button\"";
        }
        
        public void ClickNewTabButton()
        {
            newTabButton.IsEnabled();
            newTabButton.JsScrollToElement();
            newTabButton.Click();
        }

    }
}
