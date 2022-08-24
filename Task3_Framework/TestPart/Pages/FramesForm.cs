using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class FramesForm:BasePage
    {
        private static Wrapper framesWrapper;
        private static string framesWrapperName = "\"Frames wrapper on forms page\"";
        private static By framesWrapperLocator = By.XPath("//*[@id=\"framesWrapper1\"]");
        private static string pageName = "\"Frames form\"";

        public HighFrame highFrame = new HighFrame();
        public LowFrame lowFrame = new LowFrame();

        public FramesForm() : base(framesWrapper = new Wrapper(framesWrapperLocator, framesWrapperName), pageName)
        {
            locator = framesWrapperLocator;
            elementName = framesWrapperName;
        }
    }
}
