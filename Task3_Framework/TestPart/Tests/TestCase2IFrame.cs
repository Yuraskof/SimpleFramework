using NUnit.Framework;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.Pages;

namespace Task3_Framework.TestPart.Tests
{
    class TestCase2IFrame:BaseTest
    {
        [Test]
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

            alertsPage.menuPage.OpenNestedFramesForm();

            NestedFramesPage nestedFramesPage = new NestedFramesPage();

            Assert.IsTrue(nestedFramesPage.isPageOpen(), "Nested frames form isn't open");

            string parentFrameText = nestedFramesPage.parentChildFramesPage.GetTextFromTheParentFrame();

            Assert.AreEqual(parentFrameText, ConfigUtils.TestData["ParentFrameText"]);

            string childFrameText = nestedFramesPage.parentChildFramesPage.GetTextFromTheChildFrame();

            Assert.AreEqual(childFrameText, ConfigUtils.TestData["ChildFrameText"]);

            BrowserUtils.SwitchToTopLevel();

            log.Info("Step 2 completed successfully");

            alertsPage.menuPage.OpenFramesForm();

            FramesForm framesPage = new FramesForm();

            string highFormText = framesPage.highLowFramesPage.GetTextFromHighFrame();

            BrowserUtils.SwitchToTopLevel();

            string lowFormText = framesPage.highLowFramesPage.GetTextFromLowFrame();

            Assert.AreEqual(highFormText, lowFormText);

            log.Info("Step 3 completed successfully. Test case \"IFrame\" completed.");
        }
    }
}