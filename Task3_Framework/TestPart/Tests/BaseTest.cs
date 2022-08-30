using log4net;
using NUnit.Framework;
using Task3_Framework.FrameworkPart.UtilClasses;

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
            FilesUtils.ClearDownloadFolder();
        }

        [TearDown]
        public void close_Browser()
        {
            DriverUtils.WebDriver.Quit();
            DriverUtils.ResetDriver();
            ConfigUtils.ClearData();
        }
    }
}
