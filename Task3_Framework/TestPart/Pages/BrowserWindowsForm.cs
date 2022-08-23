

using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class BrowserWindowsForm:BasePage
    {
        private By browserWindowsFormBaseElement = By.XPath("//*[@id= \"tabButton\"]");
        private string browserFormBaseElementName = "\"Browser windows form\"";
        private By newTabButton = By.XPath("//*[@id= \"tabButton\"]");
        private string newTabButtonName = "\"New tab button\"";

        public BrowserWindowsForm()
        {
            uniqueElement = browserWindowsFormBaseElement;
            name = browserFormBaseElementName;
            BrowserWindowsForm browserWindowsForm = new BrowserWindowsForm(browserWindowsFormBaseElement, browserFormBaseElementName);
        }

        public BrowserWindowsForm(By locator, string name) : base(locator, name)
        {

        }

        public void ClickNewTabButton()
        {
            Button button = new Button(newTabButton, newTabButtonName);
            button.IsEnabled(newTabButton, newTabButtonName);
            button.Click(newTabButton, newTabButtonName);
        }

    }
}
