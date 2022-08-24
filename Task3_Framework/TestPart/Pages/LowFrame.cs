using OpenQA.Selenium;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class LowFrame:BasePage
    {
        private static By lowFrameLocator = By.XPath("//*[@id = \"frame2\"]");
        private static string pageName = "\"Low form\"";
        private static TextField lowFrameTextField;
        private static By lowFrameTextFieldLocator = By.XPath(string.Format("//h1[contains (text(), \"{0}\")]", ConfigUtils.TestData["FramesText"]));
        private static string lowFrameTextFieldName = "\"Low form text\"";

        public LowFrame() : base(lowFrameTextField = new TextField(lowFrameTextFieldLocator, lowFrameTextFieldName), pageName)
        {
            locator = lowFrameTextFieldLocator;
            elementName = lowFrameTextFieldName;
        }
        

        public string GetTextFromLowFrame()
        {
            BrowserUtils.SwitchToFrame(lowFrameLocator, pageName);
            return lowFrameTextField.SaveText();
        }
    }
}
