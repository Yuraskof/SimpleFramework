using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class HighFrame:BasePage
    {
        private By highFrame = By.XPath("//*[@id = \"frame1\"]");
        private string highFrameName = "\"High form\"";
        private By highFrameTextField = By.XPath(string.Format("//h1[contains (text(), \"{0}\")]", ConfigUtils.TestData["FramesText"]));
        private string highFrameTextFieldName = "\"High form text\"";

        public HighFrame()
        {
            uniqueElement = highFrameTextField;
            name = highFrameName;
            HighFrame highFrame = new HighFrame(highFrameTextField, highFrameName);
        }

        public HighFrame(By locator, string name) : base(locator, name)
        {

        }

        public string GetTextFromHighFrame()
        {
            BrowserUtils.SwitchToFrame(this.highFrame, highFrameTextFieldName);
            TextField text = new TextField(this.highFrameTextField, highFrameTextFieldName);
            return text.SaveText(this.highFrameTextField, highFrameTextFieldName);
        }
    }
}
