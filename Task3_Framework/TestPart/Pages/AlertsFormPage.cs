using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task2_SeleniumWebDriver.Steam.FrameworkPart;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class AlertsFormPage:BasePage
    {
        private By alertsFormPageBaseElement = By.XPath("//*[@id = \"javascriptAlertsWrapper\"]");
        private string pageName = "alertsForm page";
        private By simpleAlertButton = By.XPath("//*[@id = \"alertButton\"]");
        private string simpleAlertButtonName = "simple alert";


        public AlertsFormPage()
        {
            uniqueElement = alertsFormPageBaseElement;
            name = pageName;
            AlertsFormPage alertsFormPage = new AlertsFormPage(alertsFormPageBaseElement, pageName);
        }

        public AlertsFormPage(By locator, string name) : base(locator, name)
        {

        }

        public void ClickAlert()
        {
            Button alertsButton = new Button(this.simpleAlertButton, simpleAlertButtonName);

            //alertsButton.JsScrollToElement(this.alertsButton, alertsButtonName);

            alertsButton.Click(this.simpleAlertButton, simpleAlertButtonName);
        }
    }
}
