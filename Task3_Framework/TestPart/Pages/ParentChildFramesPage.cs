using OpenQA.Selenium;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class ParentChildFramesPage:BasePage
    {
        private static By parentFrameLocator = By.XPath("//*[@id = \"frame1\"]");
        private static string parentFrameName = "\"Parent frame\"";
        private static TextField parentFrameTextField;
        private static By childFrameLocator = By.XPath("//*[contains(@srcdoc, \"Child\")]");
        private static string childFrameName = "\"Child frame\"";
        private static TextField childFrameTextField = new TextField(By.XPath(string.Format("//p[contains (text(), \"{0}\")]", ConfigUtils.TestData["ChildFrameText"])), "\"Child frame text\"");


        public ParentChildFramesPage() : base(parentFrameTextField = new TextField(By.XPath(string.Format("//body[contains(text(), \"{0}\")]", ConfigUtils.TestData["ParentFrameText"])), "\"Parent frame text field\""), "\"Parent and child frames page\"")
        {
            locator = By.XPath(string.Format("//body[contains(text(), \"{0}\")]", ConfigUtils.TestData["ParentFrameText"]));
            elementName = "\"Parent frame text field\"";
        }

        public string GetTextFromTheParentFrame()
        {
            BrowserUtils.SwitchToFrame(parentFrameLocator, parentFrameName);
            return parentFrameTextField.SaveText();
        }

        public string GetTextFromTheChildFrame()
        {
            BrowserUtils.SwitchToFrame(childFrameLocator, childFrameName);
            return childFrameTextField.SaveText();
        }
    }
}
