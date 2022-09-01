using OpenQA.Selenium;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class HighLowFramesPage:BasePage
    {
        private static By highFrameLocator = By.XPath("//*[@id = \"frame1\"]");
        private static string highFrameName = "\"High frame\"";
        private static TextField highFrameTextField;
        private static By lowFrameLocator = By.XPath("//*[@id = \"frame2\"]");
        private static string pageName = "\"Low frame\"";
        private static TextField lowFrameTextField = new TextField(By.XPath(string.Format("//h1[contains (text(), \"{0}\")]", ConfigUtils.TestData["FramesText"])), "\"Low form text\"");
        

        public HighLowFramesPage() : base(highFrameTextField = new TextField(By.XPath(string.Format("//h1[contains (text(), \"{0}\")]", ConfigUtils.TestData["FramesText"])), "\"High frame text\""), "\"High and low frames page\"")
        {
        }

        public string GetTextFromHighFrame()
        {
            BrowserUtils.SwitchToFrame(highFrameLocator, pageName);
            return highFrameTextField.SaveText();
        }

        public string GetTextFromLowFrame()
        {
            BrowserUtils.SwitchToFrame(lowFrameLocator, pageName);
            return lowFrameTextField.SaveText();
        }
    }
}
