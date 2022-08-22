using log4net;
using NUnit.Framework;

namespace Task3_Framework.TestPart.Tests
{
    public abstract class BaseTest
    {
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [SetUp]
        public void Setup()
        {
            ConfigUtils.GetBrowserConfig();

            DriverUtils.getInstance(); 

            DriverUtils.WebDriver.Manage().Window.Maximize(); 

            ConfigUtils.GetTestData();
        }

        [TearDown]
        public void close_Browser()
        {
            DriverUtils.WebDriver.Quit();
            DriverUtils.ResetDriver();
            ConfigUtils.ClearData();
        }



        //public MainPage mainPage = new MainPage();

        //public bool OpenMainPage()
        //{
        //    BrowserUtils.GoToUrl(DriverUtils.BrowserConfig["baseUrl"]);
        //    return mainPage.isPageOpen();
        //}
    }
}
