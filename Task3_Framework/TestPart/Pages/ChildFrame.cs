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
        private By childFrameUniqueElement = By.XPath(string.Format("//p[contains (text(), \"{0}\")]", ConfigUtils.TestData["ChildFrameText"]));
        private string childFrameElementName = "\"Child frame text\"";

        public ChildFrame()
        {
            uniqueElement = childFrameUniqueElement;
            name = childFrameName;
            ChildFrame childFrame = new ChildFrame(childFrameUniqueElement, childFrameName);
        }

        public ChildFrame(By locator, string name) : base(locator, name)
        {

        }

        public string GetTextFromTheChildFrame()
        {
            BrowserUtils.SwitchToFrame(this.childFrame, childFrameName);
            TextField confirmationResult = new TextField(this.childFrameUniqueElement, childFrameElementName);
            return confirmationResult.SaveText(this.childFrameUniqueElement, childFrameElementName);
        }
    }
}
