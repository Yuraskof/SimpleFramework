using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;

namespace Task3_Framework.TestPart
{
    public class MainPage : BasePage
    {
        private static Button alertsButton;
        private static By elementsButtonLocator = By.XPath(string.Format("//div[@class = \"card-body\"]//h5[contains(text(), \"{0}\")]", ConfigUtils.TestData["ElementsWindows"]));
        private static string elementsButtonName = "\"Elements button\"";
        private static Button elementsButton = new Button(elementsButtonLocator, elementsButtonName);
        private static By widgetsButtonLocator = By.XPath(string.Format("//div[@class = \"card-body\"]//h5[contains(text(), \"{0}\")]", ConfigUtils.TestData["WidgetsWindows"]));
        private static string widgetsButtonName = "\"Widgets button\"";
        private static Button widgetsButton = new Button(widgetsButtonLocator, widgetsButtonName);

        public MainPage() : base(alertsButton = new Button(By.XPath(string.Format("//div[@class = \"card-body\"]//h5[contains(text(), \"{0}\")]", ConfigUtils.TestData["AlertsFramesWindows"])), "\"Alerts button\""), "\"Main page\"")
        {
            locator = By.XPath(string.Format("//div[@class = \"card-body\"]//h5[contains(text(), \"{0}\")]", ConfigUtils.TestData["AlertsFramesWindows"]));
            elementName = "\"Alerts button\"";
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

        public void GoToWidgetsPage()
        {
            widgetsButton.JsScrollToElement();
            widgetsButton.Click();
        }
    }
}
