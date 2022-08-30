using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;


namespace Task3_Framework.TestPart.Pages
{
    class NestedFramesPage:BasePage
    {
        private static Wrapper framesWrapper;
        public ParentChildFramesPage parentChildFramesPage = new ParentChildFramesPage();
        
        public NestedFramesPage() : base(framesWrapper = new Wrapper(By.XPath("//*[@id=\"framesWrapper\"]"), "\"Frames wrapper\""), "\"Nested forms page\"")
        {
            locator = By.XPath("//*[@id=\"framesWrapper\"]");
            elementName = "\"Frames wrapper\"";
        }
    }
}
