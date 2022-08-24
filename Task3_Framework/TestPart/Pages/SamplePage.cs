using OpenQA.Selenium;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class SamplePage:BasePage
    {
        private static TextField samplePageTextField;
        private static By samplePageTextFieldLocator = By.XPath("//*[@id =\"sampleHeading\"]");
        private static string samplePageTextFieldName = "\"Sample text field\"";
        private static string pageName = "\"Sample page\"";

        public SamplePage() : base(samplePageTextField = new TextField(samplePageTextFieldLocator, samplePageTextFieldName), pageName)
        {
            locator = samplePageTextFieldLocator;
            elementName = samplePageTextFieldName;
        }

        public bool CheckUrl()
        {
            return BrowserUtils.GetUrl().Contains(ConfigUtils.TestData["Url"]);
        }
    }
}
