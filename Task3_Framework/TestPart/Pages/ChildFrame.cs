using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class ChildFrame:BasePage
    {
        private By childFrame = By.XPath("//*[contains(@srcdoc, \"Child\")]");
        private string childFrameName = "\"Child frame\"";
        private By childFrameTextField = By.XPath(string.Format("//p[contains (text(), \"{0}\")]", ConfigUtils.TestData["ChildFrameText"]));
        private string childFrameTextFieldName = "\"Child frame text\"";

        public ChildFrame()
        {
            uniqueElement = childFrameTextField;
            name = childFrameName;
            ChildFrame childFrame = new ChildFrame(childFrameTextField, childFrameName);
        }

        public ChildFrame(By locator, string name) : base(locator, name)
        {

        }

        public string GetTextFromTheChildFrame()
        {
            BrowserUtils.SwitchToFrame(this.childFrame, childFrameName);
            TextField text = new TextField(this.childFrameTextField, childFrameTextFieldName);
            return text.SaveText(this.childFrameTextField, childFrameTextFieldName);
        }
    }
}
