using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using Task2_SeleniumWebDriver.Steam.FrameworkPart.BrowserUtils;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart
{
    class MainPage : BasePage
    {
        private By mainPageBaseElement= By.XPath("//div[@class = \"home-content\"]");
        private string pageName = "main page";
        private By alertsButton = By.XPath(string.Format("//div[@class = \"card-body\"]//h5[contains(text(), \"{0}\")]", ConfigUtils.TestData["AlertsFramesWindows"]));
        private string alertsButtonName = "alerts button";

        public MainPage()
        {
            uniqueElement = mainPageBaseElement;
            name = pageName;
            MainPage mainPage = new MainPage(mainPageBaseElement, pageName);
        }

        public MainPage(By locator, string name) : base(locator, name)
        {
            
        }


        public void GoToAlertsPage()
        {
            Button alertsButton = new Button(this.alertsButton, alertsButtonName);

            alertsButton.JsScrollToElement(this.alertsButton, alertsButtonName);
            
            alertsButton.Click(this.alertsButton, alertsButtonName);
        }


        //public bool CheckMainPageIsOpen()
        //{
        //    var elements = DriverUtils.WebDriver.FindElements(By.XPath(mainPageBaseElement));
        //    return elements.Count > 0;
        //}

        //IFrame googleIframe = new IFrame(this.googleIframe, "google iframe");

        //if (googleIframe.Find(this.googleIframe, "google iframe"))
        //{
        //    googleIframe.SwitchToAnotherFrame(this.googleIframe, "google iframe");
        //}

        //Button advButton = new Button(closeAdvertisingWindow, "advertising button");

        //if (advButton.Find(closeAdvertisingWindow, "advertising button"))
        //{
        //    advButton.Click(closeAdvertisingWindow, "advertising button");
        //}

        //googleIframe.SwitchToTopLevel();
    }
}
