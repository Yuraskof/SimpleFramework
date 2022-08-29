﻿using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class AlertsFormPage:BasePage
    {
        private static Button simpleAlertsButton;
        private static By twoOptionsAlertButtonLocator = By.XPath("//*[@id = \"confirmButton\"]");
        private static string twoOptionsAlertButtonName = "\"Two options alert\"";
        private static Button twoOptionsAlertsButton = new Button(twoOptionsAlertButtonLocator, twoOptionsAlertButtonName);
        private static By twoOptionsConfirmResultLocator = By.XPath("//*[@id = \"confirmResult\"]");
        private static string twoOptionsAlertResultName = "\"Two options alert confirmation result\"";
        private static TextField twoOptionsAlertConfirmation = new TextField(twoOptionsConfirmResultLocator, twoOptionsAlertResultName);
        private static By alertWithTextButtonLocator = By.XPath("//*[@id = \"promtButton\"]");
        private static string alertWithTextButtonName = "\"Alert with text\"";
        private static Button alertWithTextButton = new Button(alertWithTextButtonLocator, alertWithTextButtonName);
        private static By alertWithTextConfirmResultLocator = By.XPath("//*[@id = \"promptResult\"]");
        private static string alertWithTextResultName = "\"Alert with text confirmation result\"";
        private static TextField alertWithTextConfirmation = new TextField(alertWithTextConfirmResultLocator, alertWithTextResultName);
        private static By pageHeaderLocator = By.XPath("//div[@class = \"main-header\"]");
        private static string pageHeaderName = "\"Alerts form page header\"";
        private static Header pageHeader = new Header(pageHeaderLocator, pageHeaderName);

        public AlertsFormPage() : base(simpleAlertsButton = new Button(By.XPath("//*[@id = \"alertButton\"]"), "\"Simple alert\""), "\"AlertsForm page\"")
        {
            locator = By.XPath("//*[@id = \"alertButton\"]");
            elementName = "\"Simple alert\"";
        }

        public void ClickSimpleAlert()
        {
            pageHeader.IsEnabled();
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
