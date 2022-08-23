using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class ParentFrame:BasePage
    {
        private By parentFrame = By.XPath("//*[@id = \"frame1\"]");
        private string parentFrameName = "\"Parent frame\"";
        private By parentFrameTextField = By.XPath(string.Format("//body[contains(text(), \"{0}\")]", ConfigUtils.TestData["ParentFrameText"]));
        private string parentTextFieldName = "\"Parent frame text\"";

        public ChildFrame childFrame = new ChildFrame();

        public ParentFrame()
        {
            uniqueElement = parentFrameTextField;
            name = parentFrameName;
            ParentFrame mainPage = new ParentFrame(parentFrameTextField, parentFrameName);
        }

        public ParentFrame(By locator, string name) : base(locator, name)
        {

        }

        public string GetTextFromTheParentFrame()
        {
            BrowserUtils.SwitchToFrame(this.parentFrame, parentFrameName);
            TextField text = new TextField(this.parentFrameTextField, parentTextFieldName);
            return text.SaveText(this.parentFrameTextField, parentTextFieldName);
        }
    }
}
