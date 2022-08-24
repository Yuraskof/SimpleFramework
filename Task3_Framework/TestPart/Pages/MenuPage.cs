using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class MenuPage:BasePage
    {
        private static string pageName = "\"Menu page\"";
        private static Panel menuPanel;
        private static By menuPanelLocator = By.XPath("//div[@class =\"left-pannel\"] ");
        private static string menuPanelName = "\"Menu panel\"";
        
        private static By alertsFormButtonLocator = By.XPath(string.Format("//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["AlertsForm"]));
        private static string alertsFormButtonName = "\"Alerts form button\"";
        private static Button alertsFormButton = new Button(alertsFormButtonLocator, alertsFormButtonName);


        private static By nestedFramesButton = By.XPath(string.Format("//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["NestedFrames"]));
        private static string nestedFramesButtonName = "\"Nested frames button\"";
        private static By webTablesFormButton = By.XPath(string.Format("//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["WebTablesForm"]));
        private static string webTablesFormButtonName = "\"WebTablesForm Button\"";
        private static By browserFormButton = By.XPath(string.Format("//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["BrowserForm"]));
        private static string browserFormButtonName = "\"Browser form button\"";
        private static By elementsButton = By.XPath(string.Format("//*[@class= \"header-text\"][contains(text(), \"{0}\")]", ConfigUtils.TestData["ElementsWindows"]));
        private static string elementsButtonName = "\"Elements button\"";
        private static By linksFormButton = By.XPath(string.Format("//*[(text() = \"{0}\")]", ConfigUtils.TestData["LinksButton"]));
        private static string linksFormButtonName = "\"Links button\"";
        private static By framesButton = By.XPath(string.Format("//span[text()=\"{0}\"]", ConfigUtils.TestData["FramesForm"]));
        private static string framesButtonName = "\"Frames button\""; 

        public MenuPage() : base(menuPanel = new Panel(menuPanelLocator, menuPanelName), pageName)
        {
            locator = menuPanelLocator;
            elementName = menuPanelName;
        }

        public void OpenAlertsForm()
        {
            alertsFormButton.JsScrollToElement();
            alertsFormButton.Click();
        }

        //public void OpenNestedFramesForm()
        //{
        //    Button alertsFormButton = new Button(nestedFramesButton, nestedFramesButtonName);
        //    alertsFormButton.JsScrollToElement(nestedFramesButton, nestedFramesButtonName);
        //    alertsFormButton.Click(nestedFramesButton, nestedFramesButtonName);
        //}

        //public void OpenFramesForm()
        //{
        //    Button button = new Button(framesButton, framesButtonName);
        //    button.JsScrollToElement(framesButton, framesButtonName);
        //    button.Click(framesButton, framesButtonName);
        //}

        //public void OpenWebTablesForm()
        //{
        //    Button webTablesFormButton = new Button(this.webTablesFormButton, webTablesFormButtonName);
        //    webTablesFormButton.JsScrollToElement(this.webTablesFormButton, webTablesFormButtonName);
        //    webTablesFormButton.Click(this.webTablesFormButton, webTablesFormButtonName);
        //}

        //public void OpenBrowserWindowsForm()
        //{
        //    Button browserFormButton = new Button(this.browserFormButton, browserFormButtonName);
        //    browserFormButton.JsScrollToElement(this.browserFormButton, browserFormButtonName);
        //    browserFormButton.Click(this.browserFormButton, browserFormButtonName);
        //}

        //public void OpenElementsPage()
        //{
        //    Button elementsButton = new Button(this.elementsButton, elementsButtonName);
        //    elementsButton.Click(this.elementsButton, elementsButtonName);
        //}

        //public void OpenLinksForm()
        //{
        //    Button linksFormButton = new Button(this.linksFormButton, linksFormButtonName);
        //    linksFormButton.JsScrollToElement(this.linksFormButton, linksFormButtonName);
        //    linksFormButton.IsEnabled(this.linksFormButton, linksFormButtonName);
        //    linksFormButton.Click(this.linksFormButton, linksFormButtonName);
        //}

    }
}
