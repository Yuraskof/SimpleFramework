using OpenQA.Selenium;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class ParentFrame:BasePage
    {
        private static By parentFrameLocator = By.XPath("//*[@id = \"frame1\"]");
        private static string parentFrameName = "\"Parent frame\"";
        private static TextField parentFrameTextField;
        private static By parentFrameTextFieldLocator = By.XPath(string.Format("//body[contains(text(), \"{0}\")]", ConfigUtils.TestData["ParentFrameText"]));
        private static string parentTextFieldName = "\"Parent frame text field\"";

        public ChildFrame childFrame = new ChildFrame();
        
        public ParentFrame() : base(parentFrameTextField = new TextField(parentFrameTextFieldLocator, parentTextFieldName), parentFrameName)
        {
            locator = parentFrameTextFieldLocator;
            elementName = parentTextFieldName;
        }

        public string GetTextFromTheParentFrame()
        {
            BrowserUtils.SwitchToFrame(parentFrameLocator, parentFrameName);
            return parentFrameTextField.SaveText();
        }
    }
}
