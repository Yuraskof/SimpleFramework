using System.IO;
using OpenQA.Selenium;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class UploadDownloadForm:BasePage
    {
        private static Button downloadButton;
        private static Header pageHeader = new Header(By.XPath("//div[@class = \"main-header\"]"), "\"Upload download page header\"");
        private static Button uploadButton = new Button(By.XPath("//*[@id= \"uploadFile\"]"), "\"Upload button\"");
        private static TextField uploadedFilePath = new TextField(By.XPath("//*[@id= \"uploadedFilePath\"]"), "\"Uploaded file path text field\"");
        private string fileName;

        public UploadDownloadForm() : base(downloadButton = new Button(By.XPath("//*[@id = \"downloadButton\"]"), "\"Download button\""), "\"Upload and download page\"")
        {
            locator = By.XPath("//*[@id = \"downloadButton\"]");
            elementName = "\"Download button\"";
        }

        public bool DownloadFile()
        {
            pageHeader.IsEnabled();
            downloadButton.JsScrollToElement();
            downloadButton.IsEnabled();
            fileName = downloadButton.GetAttribute("download");
            downloadButton.Click();
            return FilesUtils.CheckDownloadFile(fileName);
        }

        public void UploadFile()
        {
            string uploadFilePath = Directory.GetCurrentDirectory() + "\\downloads\\" + fileName;
            uploadButton.SendKeys(@uploadFilePath);
        }

        public bool CheckUploadedFilePath()
        {
            return uploadedFilePath.SaveText().Contains(fileName);
        }
    }
}
