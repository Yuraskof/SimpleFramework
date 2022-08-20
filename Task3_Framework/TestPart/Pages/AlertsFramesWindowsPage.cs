using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;

namespace Task3_Framework.TestPart.Pages
{
    class AlertsFramesWindowsPage :BasePage
    {
        private By alertsPageBaseElement = By.XPath("//div[contains(@class, \"show\")]//span[contains(text(), \"Alerts\")]");
        private string pageName = "alerts page";


        public MenuPage menuPage = new MenuPage();
        public AlertsFormPage alertsFormPage = new AlertsFormPage();

        public AlertsFramesWindowsPage()
        {
            uniqueElement = alertsPageBaseElement;
            name = pageName;
            AlertsFramesWindowsPage alertsPage = new AlertsFramesWindowsPage(alertsPageBaseElement, pageName);
        }

        public AlertsFramesWindowsPage(By locator, string name) : base(locator, name)
        {

        }
    }
}
