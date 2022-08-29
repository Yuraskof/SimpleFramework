using System;
using NUnit.Framework;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.Pages;

namespace Task3_Framework.TestPart.Tests
{
    class TestCase1Alerts: BaseTest
    {
        [Test]
        public void CheckAlertForms()
        {
            log.Info("Test case \"AlertForms\" started.");

            BrowserUtils.GoToUrl(DriverUtils.BrowserConfig["baseUrl"]);

            MainPage mainPage = new MainPage();

            Assert.IsTrue(mainPage.isPageOpen(), "Main page isn't open");

            log.Info("Step 1 completed successfully");

            mainPage.GoToAlertsPage();

            AlertsFramesWindowsPage alertsPage = new AlertsFramesWindowsPage();

            Assert.IsTrue(alertsPage.isPageOpen(), "Alerts page isn't open");

            alertsPage.menuPage.OpenAlertsForm();

            AlertsFormPage alertsFormPage = new AlertsFormPage();

            Assert.IsTrue(alertsFormPage.isPageOpen(), "Alerts form isn't open");

            log.Info("Step 2 completed successfully");

            alertsFormPage.ClickSimpleAlert();

            Assert.IsTrue(BrowserUtils.AlertIsPresent(DriverUtils.wait), "Simple alert isn't open");

            string simpleAlertText = BrowserUtils.GetTextFromAlert();

            Assert.AreEqual(simpleAlertText, ConfigUtils.TestData["SimpleAlertMessage"], "Wrong message");

            log.Info("Step 3 completed successfully");

            BrowserUtils.AcceptAlert(DriverUtils.wait);

            Assert.Null(BrowserUtils.SwitchToAlert(), "Simple alert is open");

            log.Info("Step 4 completed successfully");

            alertsFormPage.ClickTwoOptionsAlert();

            Assert.IsTrue(BrowserUtils.AlertIsPresent(DriverUtils.wait), "Two options alert isn't open");

            string twoOptionsAlertText = BrowserUtils.GetTextFromAlert();

            Assert.AreEqual(twoOptionsAlertText, ConfigUtils.TestData["TwoOptionsAlertMessage"], "Wrong message");

            log.Info("Step 5 completed successfully");

            BrowserUtils.AcceptAlert(DriverUtils.wait);

            Assert.Null(BrowserUtils.SwitchToAlert(), "Two options alert is open");

            string twoOptionsAlertConfirmationText = alertsFormPage.Get2OptAlertConfirmText();

            Assert.AreEqual(twoOptionsAlertConfirmationText, ConfigUtils.TestData["TwoOptionsAlertConfirmText"], "Wrong message");

            log.Info("Step 6 completed successfully");

            alertsFormPage.ClickAlertWithText();

            Assert.IsTrue(BrowserUtils.AlertIsPresent(DriverUtils.wait), "Alert with text field isn't open");

            string alertWithTextMessage = BrowserUtils.GetTextFromAlert();

            Assert.AreEqual(alertWithTextMessage, ConfigUtils.TestData["AlertWithTextMessage"], "Wrong message");

            log.Info("Step 7 completed successfully");

            string generatedText = StringUtil.StringGenerator(Convert.ToInt32(ConfigUtils.TestData["LettersCount"]));

            BrowserUtils.AlertSendKeys(generatedText, DriverUtils.wait);
            BrowserUtils.AcceptAlert(DriverUtils.wait);

            Assert.Null(BrowserUtils.SwitchToAlert(), "Alert with text is open");

            string alertWithTextConfirmResult = alertsFormPage.GetAlertWithTextComfirmText();

            Assert.AreEqual(alertWithTextConfirmResult, string.Format(ConfigUtils.TestData["AlertWithTextResult"] + generatedText), "Wrong message");

            log.Info("Step 7 completed successfully. Test case \"AlertForms\" completed.");
        }
    }
}
