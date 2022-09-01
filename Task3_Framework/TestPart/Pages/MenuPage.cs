using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class MenuPage:BasePage
    {
        private static Panel menuPanel;
        private static Button alertsFormButton = new Button(By.XPath(string.Format("//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["AlertsForm"])), "\"Alerts form button\"");
        private static Button nestedFramesButton = new Button(By.XPath(string.Format("//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["NestedFrames"])), "\"Nested frames button\"");
        private static Button webTablesFormButton = new Button(By.XPath(string.Format("//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["WebTablesForm"])), "\"WebTablesForm Button\"");
        private static Button browserFormButton = new Button(By.XPath(string.Format("//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["BrowserForm"])), "\"Browser form button\"");
        private static Button elementsButton = new Button(By.XPath(string.Format("//*[@class= \"header-text\"][contains(text(), \"{0}\")]", ConfigUtils.TestData["ElementsWindows"])), "\"Elements button\"");
        private static Button linksFormButton = new Button(By.XPath(string.Format("//*[(text() = \"{0}\")]", ConfigUtils.TestData["LinksButton"])), "\"Links button\"");
        private static Button framesButton = new Button(By.XPath(string.Format("//span[text()=\"{0}\"]", ConfigUtils.TestData["FramesForm"])), "\"Frames button\"");
        private static Button sliderFormButton = new Button(By.XPath(string.Format("//span[text()=\"{0}\"]", ConfigUtils.TestData["SliderForm"])), "\"Slider form button\"");
        private static Button progrBarFormButton = new Button(By.XPath(string.Format("//span[text()=\"{0}\"]", ConfigUtils.TestData["ProgressBarForm"])), "\"Progress bar form button\"");
        private static Button datePickerFormButton = new Button(By.XPath(string.Format("//span[text()=\"{0}\"]", ConfigUtils.TestData["DatePickerForm"])), "\"Date picker form button\"");
        private static Button uploadDownloadButton = new Button(By.XPath(string.Format("//span[text()=\"{0}\"]", ConfigUtils.TestData["UploadDownload"])), "\"Upload and download button\"");

        public MenuPage() : base(menuPanel = new Panel(By.XPath("//div[@class =\"left-pannel\"]"), "\"Menu panel\""), "\"Menu page\"")
        {
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

        public void OpenUploadDownloadForm()
        {
            uploadDownloadButton.JsScrollToElement();
            uploadDownloadButton.IsEnabled();
            uploadDownloadButton.Click();
        }
    }
}
