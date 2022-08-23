using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class AlertsFormPage:BasePage
    {
        private By alertsFormPageBaseElement = By.XPath("//*[@id = \"javascriptAlertsWrapper\"]");
        private string pageName = "\"AlertsForm page\"";
        private By simpleAlertButton = By.XPath("//*[@id = \"alertButton\"]");
        private string simpleAlertButtonName = "\"Simple alert\"";
        private By twoOptionsAlertButton =By.XPath("//*[@id = \"confirmButton\"]");
        private string twoOptionsAlertButtonName = "\"Two options alert\"";
        private By twoOptionsConfirmResult = By.XPath("//*[@id = \"confirmResult\"]");
        private string twoOptionsAlertResultName = "\"Two options alert confirmation result\"";
        private By alertWithTextButton = By.XPath("//*[@id = \"promtButton\"]");
        private string alertWithTextButtonName = "\"Alert with text\"";
        private By alertWithTextConfirmResult = By.XPath("//*[@id = \"promptResult\"]");
        private string alertWithTextResultName = "\"Alert with text confirmation result\"";

        public AlertsFormPage()
        {
            uniqueElement = alertsFormPageBaseElement;
            name = pageName;
            AlertsFormPage alertsFormPage = new AlertsFormPage(alertsFormPageBaseElement, pageName);
        }

        public AlertsFormPage(By locator, string name) : base(locator, name)
        {

        }

        public void ClickSimpleAlert()
        {
            Button alertsButton = new Button(this.simpleAlertButton, simpleAlertButtonName);
            alertsButton.IsEnabled(this.simpleAlertButton, simpleAlertButtonName);
            alertsButton.Click(this.simpleAlertButton, simpleAlertButtonName);
        }

        public void ClickTwoOptionsAlert()
        {
            Button alertsButton = new Button(this.twoOptionsAlertButton, twoOptionsAlertButtonName);
            alertsButton.Click(this.twoOptionsAlertButton, twoOptionsAlertButtonName);
        }

        public string Get2OptAlertConfirmText()
        {
            TextField confirmationResult = new TextField(this.twoOptionsConfirmResult, twoOptionsAlertResultName);
            return confirmationResult.SaveText(this.twoOptionsConfirmResult, twoOptionsAlertResultName);
        }

        public void ClickAlertWithText()
        {
            Button alertsButton = new Button(this.alertWithTextButton, alertWithTextButtonName);
            alertsButton.Click(this.alertWithTextButton, alertWithTextButtonName);
        }

        public string GetAlertWithTextComfirmText()
        {
            TextField confirmationResult = new TextField(this.alertWithTextConfirmResult, alertWithTextResultName);
            return confirmationResult.SaveText(this.alertWithTextConfirmResult, alertWithTextResultName);
        }
    }
}
