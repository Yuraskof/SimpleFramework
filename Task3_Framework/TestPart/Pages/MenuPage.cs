using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class MenuPage:BasePage
    {
        private static Panel menuPanel;
        private static By alertsFormButtonLocator = By.XPath(string.Format("//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["AlertsForm"]));
        private static string alertsFormButtonName = "\"Alerts form button\"";
        private static Button alertsFormButton = new Button(alertsFormButtonLocator, alertsFormButtonName);
        private static By nestedFramesButtonLocator = By.XPath(string.Format("//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["NestedFrames"]));
        private static string nestedFramesButtonName = "\"Nested frames button\"";
        private static Button nestedFramesButton = new Button(nestedFramesButtonLocator, nestedFramesButtonName);
        private static By webTablesFormButtonLocator = By.XPath(string.Format("//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["WebTablesForm"]));
        private static string webTablesFormButtonName = "\"WebTablesForm Button\"";
        private static Button webTablesFormButton = new Button(webTablesFormButtonLocator, webTablesFormButtonName);
        private static By browserFormButtonLocator = By.XPath(string.Format("//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["BrowserForm"]));
        private static string browserFormButtonName = "\"Browser form button\"";
        private static Button browserFormButton = new Button(browserFormButtonLocator, browserFormButtonName);
        private static By elementsButtonLocator = By.XPath(string.Format("//*[@class= \"header-text\"][contains(text(), \"{0}\")]", ConfigUtils.TestData["ElementsWindows"]));
        private static string elementsButtonName = "\"Elements button\"";
        private static Button elementsButton = new Button(elementsButtonLocator, elementsButtonName);
        private static By linksFormButtonLocator = By.XPath(string.Format("//*[(text() = \"{0}\")]", ConfigUtils.TestData["LinksButton"]));
        private static string linksFormButtonName = "\"Links button\"";
        private static Button linksFormButton = new Button(linksFormButtonLocator, linksFormButtonName);
        private static By framesButtonLocator = By.XPath(string.Format("//span[text()=\"{0}\"]", ConfigUtils.TestData["FramesForm"]));
        private static string framesButtonName = "\"Frames button\"";
        private static Button framesButton = new Button(framesButtonLocator, framesButtonName);
        private static By sliderFormButtonLocator = By.XPath(string.Format("//span[text()=\"{0}\"]", ConfigUtils.TestData["SliderForm"]));
        private static string sliderFormButtonName = "\"Slider form button\"";
        private static Button sliderFormButton = new Button(sliderFormButtonLocator, sliderFormButtonName);
        private static By progrBarFormButtonLocator = By.XPath(string.Format("//span[text()=\"{0}\"]", ConfigUtils.TestData["ProgressBarForm"]));
        private static string progrBarFormButtonName = "\"Progress bar form button\"";
        private static Button progrBarFormButton = new Button(progrBarFormButtonLocator, progrBarFormButtonName);
        private static By datePickerFormButtonLocator = By.XPath(string.Format("//span[text()=\"{0}\"]", ConfigUtils.TestData["DatePickerForm"]));
        private static string datePickerFormButtonName = "\"Date picker form button\"";
        private static Button datePickerFormButton = new Button(datePickerFormButtonLocator, datePickerFormButtonName);

        public MenuPage() : base(menuPanel = new Panel(By.XPath("//div[@class =\"left-pannel\"]"), "\"Menu panel\""), "\"Menu page\"")
        {
            locator = By.XPath("//div[@class =\"left-pannel\"]");
            elementName = "\"Menu panel\"";
        }

        public void OpenAlertsForm()
        {
            alertsFormButton.JsScrollToElement();
            alertsFormButton.Click();
        }

        public void OpenNestedFramesForm()
        {
            nestedFramesButton.JsScrollToElement();
            nestedFramesButton.Click();
        }

        public void OpenFramesForm()
        {
            framesButton.JsScrollToElement();
            framesButton.Click();
        }

        public void OpenWebTablesForm()
        {
            webTablesFormButton.JsScrollToElement();
            webTablesFormButton.Click();
        }

        public void OpenBrowserWindowsForm()
        {
            browserFormButton.JsScrollToElement();
            browserFormButton.Click();
        }

        public void OpenElementsPage()
        {
            elementsButton.Click();
        }

        public void OpenLinksForm()
        {
            linksFormButton.JsScrollToElement();
            linksFormButton.IsEnabled();
            linksFormButton.Click();
        }

        public void OpenSliderForm()
        {
            sliderFormButton.JsScrollToElement();
            sliderFormButton.IsEnabled();
            sliderFormButton.Click();
        }

        public void OpenProgressBarForm()
        {
            progrBarFormButton.JsScrollToElement();
            progrBarFormButton.IsEnabled();
            progrBarFormButton.Click();
        }

        public void OpenDatePickerForm()
        {
            datePickerFormButton.JsScrollToElement();
            datePickerFormButton.IsEnabled();
            datePickerFormButton.Click();
        }
    }
}
