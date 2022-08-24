using OpenQA.Selenium;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class HighFrame:BasePage
    {
        private static By highFrameLocator = By.XPath("//*[@id = \"frame1\"]");
        private static string pageName = "\"High form\"";
        private static TextField highFrameTextField;
        private static By highFrameTextFieldLocator = By.XPath(string.Format("//h1[contains (text(), \"{0}\")]", ConfigUtils.TestData["FramesText"]));
        private static string highFrameTextFieldName = "\"High form text\"";

        public HighFrame() : base(highFrameTextField = new TextField(highFrameTextFieldLocator, highFrameTextFieldName), pageName)
        {
            locator = highFrameTextFieldLocator;
            elementName = highFrameTextFieldName;
        }

        public string GetTextFromHighFrame()
        {
            BrowserUtils.SwitchToFrame(highFrameLocator, pageName);
            return highFrameTextField.SaveText();
        }
    }
}
