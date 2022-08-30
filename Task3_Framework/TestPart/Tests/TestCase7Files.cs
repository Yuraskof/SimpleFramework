using NUnit.Framework;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.Pages;

namespace Task3_Framework.TestPart.Tests
{
    class TestCase7Files:BaseTest
    {
        [Test]
        public void UploadDownload()
        {
            log.Info("Test case \"Uploading and downloading\" started.");

            BrowserUtils.GoToUrl(DriverUtils.BrowserConfig["baseUrl"]);

            MainPage mainPage = new MainPage();

            Assert.IsTrue(mainPage.isPageOpen(), "Main page isn't open");

            log.Info("Step 1 completed successfully");

            mainPage.GoToElementsPage();

            ElementsPage elementsPage = new ElementsPage();

            elementsPage.menuPage.OpenUploadDownloadForm();

            UploadDownloadForm uploadDownloadForm = new UploadDownloadForm();

            Assert.IsTrue(uploadDownloadForm.isPageOpen(), "Upload and download form isn't open");

            Assert.IsTrue(uploadDownloadForm.DownloadFile(), "File isn't download"); 


            log.Info("Step 3 completed successfully. Test case \"Uploading and downloading\" completed.");
        }
    }
}
