using OpenQA.Selenium;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class ChildFrame:BasePage
    {
        private static By childFrameLocator = By.XPath("//*[contains(@srcdoc, \"Child\")]");
        private static string childFrameName = "\"Child frame\"";
        private static TextField childFrameTextField;
        private static By childFrameTextFieldLocator = By.XPath(string.Format("//p[contains (text(), \"{0}\")]", ConfigUtils.TestData["ChildFrameText"]));
        private static string childFrameTextFieldName = "\"Child frame text\"";

        public ChildFrame() : base(childFrameTextField = new TextField(childFrameTextFieldLocator, childFrameTextFieldName), childFrameName)
        {
            locator = childFrameTextFieldLocator;
            elementName = childFrameTextFieldName;
        }


        public string GetTextFromTheChildFrame()
        {
            BrowserUtils.SwitchToFrame(childFrameLocator, childFrameName);
            return childFrameTextField.SaveText();
        }
    }
}
