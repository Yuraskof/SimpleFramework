using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class MenuPage:BasePage
    {
        private By menuPageBaseElement = By.XPath("//div[@class =\"left-pannel\"] ");
        private string pageName = "\"Menu page\"";
        private By alertsFormButton = By.XPath(string.Format("//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["AlertsForm"]));
        private string alertsFormButtonName = "\"Alerts form button\"";
        private By nestedFramesButton = By.XPath(string.Format("//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["NestedFrames"]));
        private string nestedFramesButtonName = "\"Nested frames button\"";
        private By webTablesFormButton = By.XPath(string.Format("//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["WebTablesForm"]));
        private string webTablesFormButtonName = "\"WebTablesForm Button\"";
        private By browserFormButton = By.XPath(string.Format("//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["BrowserForm"]));
        private string browserFormButtonName = "\"Browser form button\"";
        private By elementsButton = By.XPath(string.Format("//*[@class= \"header-text\"][contains(text(), \"{0}\")]", ConfigUtils.TestData["ElementsWindows"]));
        private string elementsButtonName = "\"Elements button\"";
        private By linksFormButton = By.XPath(string.Format("//*[(text() = \"{0}\")]", ConfigUtils.TestData["LinksButton"]));
        private string linksFormButtonName = "\"Links button\"";
        

        public MenuPage()
        {
            uniqueElement = menuPageBaseElement;
            name = pageName;
            MenuPage mainPage = new MenuPage(menuPageBaseElement, pageName);
        }

        public MenuPage(By locator, string name) : base(locator, name)
        {

        }

        public void OpenAlertsForm()
        {
            Button alertsFormButton = new Button(this.alertsFormButton, alertsFormButtonName);
            alertsFormButton.JsScrollToElement(this.alertsFormButton, alertsFormButtonName);
            alertsFormButton.Click(this.alertsFormButton, alertsFormButtonName);
        }

        public void OpenNestedFramesForm()
        {
            Button alertsFormButton = new Button(nestedFramesButton, nestedFramesButtonName);
            alertsFormButton.JsScrollToElement(nestedFramesButton, nestedFramesButtonName);
            alertsFormButton.Click(nestedFramesButton, nestedFramesButtonName);
        }

        public void OpenWebTablesForm()
        {
            Button webTablesFormButton = new Button(this.webTablesFormButton, webTablesFormButtonName);
            webTablesFormButton.JsScrollToElement(this.webTablesFormButton, webTablesFormButtonName);
            webTablesFormButton.Click(this.webTablesFormButton, webTablesFormButtonName);
        }

        public void OpenBrowserWindowsForm()
        {
            Button browserFormButton = new Button(this.browserFormButton, browserFormButtonName);
            browserFormButton.JsScrollToElement(this.browserFormButton, browserFormButtonName);
            browserFormButton.Click(this.browserFormButton, browserFormButtonName);
        }

        public void OpenElementsPage()
        {
            Button elementsButton = new Button(this.elementsButton, elementsButtonName);
            elementsButton.Click(this.elementsButton, elementsButtonName);
        }

        public void OpenLinksForm()
        {
            Button linksFormButton = new Button(this.linksFormButton, linksFormButtonName);
            linksFormButton.JsScrollToElement(this.linksFormButton, linksFormButtonName);
            linksFormButton.IsEnabled(this.linksFormButton, linksFormButtonName);
            linksFormButton.Click(this.linksFormButton, linksFormButtonName);
        }

    }
}
