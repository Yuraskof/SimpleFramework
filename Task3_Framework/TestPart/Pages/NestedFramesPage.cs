using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;


namespace Task3_Framework.TestPart.Pages
{
    class NestedFramesPage:BasePage
    {
        private static Wrapper framesWrapper;
        private static By framesWrapperLocator = By.XPath("//*[@id=\"framesWrapper\"]");
        private static string framesWrapperLocatorName = "\"Frames wrapper\"";
        private static string pageName = "\"Nested forms page\"";

        public ParentFrame parentFrame = new ParentFrame();
        
        public NestedFramesPage() : base(framesWrapper = new Wrapper(framesWrapperLocator, framesWrapperLocatorName), pageName)
        {
            locator = framesWrapperLocator;
            elementName = framesWrapperLocatorName;
        }
    }
}
