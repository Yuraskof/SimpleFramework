using NUnit.Framework;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.Pages;

namespace Task3_Framework.TestPart.Tests
{
    class TestCase4Handles : BaseTest
    {
        [Test]
        public void CheckHandles()
        {
            log.Info("Test case \"Handles\" started.");

            BrowserUtils.GoToUrl(DriverUtils.BrowserConfig["baseUrl"]);
            
            MainPage mainPage = new MainPage();

            Assert.IsTrue(mainPage.isPageOpen(), "Main page isn't open");

            log.Info("Step 1 completed successfully");

            mainPage.GoToAlertsPage();

            AlertsFramesWindowsPage alertsPage = new AlertsFramesWindowsPage();

            Assert.IsTrue(alertsPage.isPageOpen(), "Alerts page isn't open");

            alertsPage.menuPage.OpenBrowserWindowsForm();

            BrowserWindowsForm browserWindowsForm = new BrowserWindowsForm();

            Assert.IsTrue(browserWindowsForm.isPageOpen(), "Browser windows form isn't open");

            log.Info("Step 2 completed successfully");

            string currentWindowHandle = BrowserUtils.SaveCurrentWindowHandle();

            browserWindowsForm.ClickNewTabButton();

            BrowserUtils.SwitchToNextTab(currentWindowHandle,2, DriverUtils.wait);

            SamplePage samplePage = new SamplePage();

            Assert.IsTrue(samplePage.isPageOpen(), "Sample page isn't open");

            Assert.IsTrue(samplePage.CheckUrl(), "Wrong reference");

            log.Info("Step 3 completed successfully");

            BrowserUtils.CloseTab();

            BrowserUtils.SwitchHandleBack(currentWindowHandle);

            Assert.IsTrue(browserWindowsForm.isPageOpen(), "Browser windows form isn't open");

            log.Info("Step 4 completed successfully");

            alertsPage.menuPage.OpenElementsPage();
            alertsPage.menuPage.OpenLinksForm();

            LinksForm linksForm = new LinksForm();

            Assert.IsTrue(linksForm.isPageOpen(), "Links form isn't open");
            
            log.Info("Step 5 completed successfully");

            string linksFormWindowHandle = BrowserUtils.SaveCurrentWindowHandle();

            linksForm.OpenHomeReference();

            BrowserUtils.SwitchToNextTab(currentWindowHandle, 2, DriverUtils.wait);

            Assert.IsTrue(mainPage.isPageOpen(), "Main page isn't open");

            log.Info("Step 6 completed successfully");

            BrowserUtils.SwitchHandleBack(linksFormWindowHandle);

            Assert.IsTrue(linksForm.isPageOpen(), "Links form isn't open");

            log.Info("Step 7 completed successfully");
        }
    }
}