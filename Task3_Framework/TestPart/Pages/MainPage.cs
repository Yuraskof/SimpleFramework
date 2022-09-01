using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;

namespace Task3_Framework.TestPart
{
    public class MainPage : BasePage
    {
        private static Button alertsButton;
        private static Button elementsButton = new Button(By.XPath(string.Format("//div[@class = \"card-body\"]//h5[contains(text(), \"{0}\")]", ConfigUtils.TestData["ElementsWindows"])), "\"Elements button\"");
        private static Button widgetsButton = new Button(By.XPath(string.Format("//div[@class = \"card-body\"]//h5[contains(text(), \"{0}\")]", ConfigUtils.TestData["WidgetsWindows"])), "\"Widgets button\"");

        public MainPage() : base(alertsButton = new Button(By.XPath(string.Format("//div[@class = \"card-body\"]//h5[contains(text(), \"{0}\")]", ConfigUtils.TestData["AlertsFramesWindows"])), "\"Alerts button\""), "\"Main page\"")
        {
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
