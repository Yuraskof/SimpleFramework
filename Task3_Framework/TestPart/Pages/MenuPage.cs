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
            Button alertsFormButton = new Button(this.nestedFramesButton, nestedFramesButtonName);
            alertsFormButton.JsScrollToElement(this.nestedFramesButton, nestedFramesButtonName);
            alertsFormButton.Click(this.nestedFramesButton, nestedFramesButtonName);
        }

        public void OpenWebTablesForm()
        {
            Button webTablesFormButton = new Button(this.webTablesFormButton, webTablesFormButtonName);
            webTablesFormButton.JsScrollToElement(this.webTablesFormButton, webTablesFormButtonName);
            webTablesFormButton.Click(this.webTablesFormButton, webTablesFormButtonName);
        }
    }
}
