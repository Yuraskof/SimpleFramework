using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class AlertsFormPage:BasePage
    {
        private static Button simpleAlertsButton;
        private static Button twoOptionsAlertsButton = new Button(By.XPath("//*[@id = \"confirmButton\"]"), "\"Two options alert\"");
        private static TextField twoOptionsAlertConfirmation = new TextField(By.XPath("//*[@id = \"confirmResult\"]"), "\"Two options alert confirmation result\"");
        private static Button alertWithTextButton = new Button(By.XPath("//*[@id = \"promtButton\"]"), "\"Alert with text\"");
        private static TextField alertWithTextConfirmation = new TextField(By.XPath("//*[@id = \"promptResult\"]"), "\"Alert with text confirmation result\"");
        private static Header pageHeader = new Header(By.XPath("//div[@class = \"main-header\"]"), "\"Alerts form page header\"");

        public AlertsFormPage() : base(simpleAlertsButton = new Button(By.XPath("//*[@id = \"alertButton\"]"), "\"Simple alert\""), "\"AlertsForm page\"")
        {
        }

        public void ClickSimpleAlert()
        {
            pageHeader.IsEnabled();
            simpleAlertsButton.JsScrollToElement();
            simpleAlertsButton.IsEnabled();
            simpleAlertsButton.Click();
        }

        public void ClickTwoOptionsAlert()
        {
            twoOptionsAlertsButton.Click();
        }

        public string Get2OptAlertConfirmText()
        {
            return twoOptionsAlertConfirmation.SaveText();
        }

        public void ClickAlertWithText()
        {
            alertWithTextButton.Click();
        }

        public string GetAlertWithTextComfirmText()
        {
            return alertWithTextConfirmation.SaveText();
        }
    }
}
