using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using NUnit.Framework;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.Pages;

namespace Task3_Framework.TestPart.Tests
{
    class TestCase2IFrame
    {
        protected static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void CheckIframes()
        {
            log.Info("Test case \"Iframe\" started.");

            BrowserUtils.GoToUrl(DriverUtils.BrowserConfig["baseUrl"]);

            MainPage mainPage = new MainPage();

            Assert.IsTrue(mainPage.isPageOpen(), "Main page isn't open");

            log.Info("Step 1 completed successfully");

            mainPage.GoToAlertsPage();

            AlertsFramesWindowsPage alertsPage = new AlertsFramesWindowsPage();

            Assert.IsTrue(alertsPage.isPageOpen(), "Alerts page isn't open");

            alertsPage.menuPage.OpenNestedFramesPage();

            Assert.IsTrue(alertsPage.nestedFramesPage.isPageOpen(), "Nested form isn't open");
        }
    }
}