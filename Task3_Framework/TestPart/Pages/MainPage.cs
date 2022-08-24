using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;

namespace Task3_Framework.TestPart
{
    public class MainPage : BasePage
    {
        private static string pageName = "\"Main page\"";
        private static Button alertsButton;
        private static string alertsButtonName = "\"Alerts button\"";
        private static By alertsButtonLocator = By.XPath(string.Format("//div[@class = \"card-body\"]//h5[contains(text(), \"{0}\")]", ConfigUtils.TestData["AlertsFramesWindows"]));
        private static By elementsButtonLocator = By.XPath(string.Format("//div[@class = \"card-body\"]//h5[contains(text(), \"{0}\")]", ConfigUtils.TestData["ElementsWindows"]));
        private static string elementsButtonName = "\"Elements button\"";
        private static Button elementsButton = new Button(elementsButtonLocator, elementsButtonName);

        public MainPage() : base(alertsButton = new Button(alertsButtonLocator, alertsButtonName), pageName)
        {
            locator = alertsButtonLocator;
            elementName = alertsButtonName;
        }
        

        public void GoToAlertsPage()
        {
            alertsButton.JsScrollToElement();
            alertsButton.Click();
        }

        public void GoToElementsPage()
        {
            elementsButton.JsScrollToElement();
            elementsButton.Click();
        }
    }
}
