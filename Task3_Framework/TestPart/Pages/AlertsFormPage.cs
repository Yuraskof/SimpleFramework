using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;

namespace Task3_Framework.TestPart.Pages
{
    class AlertsFormPage:BasePage
    {
        private By alertsFormPageBaseElement = By.XPath("//*[@id = \"javascriptAlertsWrapper\"]");
        private string pageName = "alertsForm page";
        private By alertsButton = By.XPath("");
        private string alertsButtonName = "";


        public AlertsFormPage()
        {
            uniqueElement = alertsFormPageBaseElement;
            name = pageName;
            AlertsFormPage alertsFormPage = new AlertsFormPage(alertsFormPageBaseElement, pageName);
        }

        public AlertsFormPage(By locator, string name) : base(locator, name)
        {

        }
    }
}
