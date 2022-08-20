using OpenQA.Selenium;
using Task2_SeleniumWebDriver.Steam.FrameworkPart.BrowserUtils;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class MenuPage:BasePage
    {
        private By menuPageBaseElement = By.XPath("//div[@class =\"left-pannel\"] ");
        private string pageName = "menu page";
        private By alertsFormButton = By.XPath(string.Format("//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["AlertsForm"]));
        private string alertsFormButtonName = "alerts form button";

        public MenuPage()
        {
            uniqueElement = menuPageBaseElement;
            name = pageName;
            MenuPage mainPage = new MenuPage(menuPageBaseElement, pageName);
        }

        public MenuPage(By locator, string name) : base(locator, name)
        {

        }

        public void OpenAlertsForm()
        {
            Button alertsFormButton = new Button(this.alertsFormButton, alertsFormButtonName);
            alertsFormButton.JsScrollToElement(this.alertsFormButton, alertsFormButtonName);
            alertsFormButton.Click(this.alertsFormButton, alertsFormButtonName);
        }
    }
}
