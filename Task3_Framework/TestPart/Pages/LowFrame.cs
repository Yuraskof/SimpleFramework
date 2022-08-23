using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class LowFrame:BasePage
    {
        private By lowFrame = By.XPath("//*[@id = \"frame2\"]");
        private string lowFrameName = "\"Low form\"";
        private By lowFrameTextField = By.XPath(string.Format("//h1[contains (text(), \"{0}\")]", ConfigUtils.TestData["FramesText"]));
        private string lowFrameTextFieldName = "\"Low form text\"";

        public LowFrame()
        {
            uniqueElement = lowFrameTextField;
            name = lowFrameName;
            LowFrame lowFrame = new LowFrame(lowFrameTextField, lowFrameName);
        }

        public LowFrame(By locator, string name) : base(locator, name)
        {

        }

        public string GetTextFromLowFrame()
        {
            BrowserUtils.SwitchToFrame(this.lowFrame, lowFrameTextFieldName);
            TextField confirmationResult = new TextField(this.lowFrameTextField, lowFrameTextFieldName);
            return confirmationResult.SaveText(this.lowFrameTextField, lowFrameTextFieldName);
        }
    }
}
