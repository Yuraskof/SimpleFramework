using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            string fileNameOnPage = downloadButton.GetAttribute("download");
            downloadButton.Click();
            return FilesUtils.CheckDownloadFile(fileNameOnPage);
        }

        public void UploadFile()
        {

        }
    }
}
