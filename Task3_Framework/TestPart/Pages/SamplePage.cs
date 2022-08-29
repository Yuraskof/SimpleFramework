using OpenQA.Selenium;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class SamplePage:BasePage
    {
        private static TextField samplePageTextField;

        public SamplePage() : base(samplePageTextField = new TextField(By.XPath("//*[@id =\"sampleHeading\"]"), "\"Sample text field\""), "\"Sample page\"")
        {
            locator = By.XPath("//*[@id =\"sampleHeading\"]");
            elementName = "\"Sample text field\"";
        }

        public bool CheckUrl()
        {
            return BrowserUtils.GetUrl().Contains(ConfigUtils.TestData["Url"]);
        }
    }
}
