using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class BrowserWindowsForm:BasePage
    {
        private static Button browserWindowsFormButton;
        private static string browserWindowsFormButtonName = "\"Browser windows form button\"";
        private static By browserWindowsFormButtonLocator = By.XPath("//*[@id= \"tabButton\"]");
        private static string pageName = "\"Browser windows form\"";

        private static By newTabButtonLocator = By.XPath("//*[@id= \"tabButton\"]");
        private static string newTabButtonName = "\"New tab button\"";
        private static Button newTabButton = new Button(newTabButtonLocator, newTabButtonName);

        public BrowserWindowsForm() : base(browserWindowsFormButton = new Button(browserWindowsFormButtonLocator, browserWindowsFormButtonName), pageName)
        {
            locator = browserWindowsFormButtonLocator;
            elementName = browserWindowsFormButtonName;
        }


        public void ClickNewTabButton()
        {
            newTabButton.IsEnabled();
            newTabButton.Click();
        }

    }
}
