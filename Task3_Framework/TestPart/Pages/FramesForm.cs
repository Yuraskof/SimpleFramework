using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class FramesForm:BasePage
    {
        private static Wrapper framesWrapper;

        public HighLowFramesPage highLowFramesPage = new HighLowFramesPage();

        public FramesForm() : base(framesWrapper = new Wrapper(By.XPath("//*[@id=\"framesWrapper1\"]"), "\"Frames wrapper on forms page\""), "\"Frames form\"")
        {
            locator = By.XPath("//*[@id=\"framesWrapper1\"]");
            elementName = "\"Frames wrapper on forms page\"";
        }
    }
}
