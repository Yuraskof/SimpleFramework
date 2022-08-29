using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.Pages;

namespace Task3_Framework.TestPart.Tests
{
    internal class TestCase6DatePicker:BaseTest
    {
        [Test]
        public void CheckDatePicker()
        {
            log.Info("Test case \"DatePicker\" started.");

            BrowserUtils.GoToUrl(DriverUtils.BrowserConfig["baseUrl"]);

            MainPage mainPage = new MainPage();

            Assert.IsTrue(mainPage.isPageOpen(), "Main page isn't open");

            log.Info("Step 1 completed successfully");

            mainPage.GoToWidgetsPage();

            WidgetsPage widgetsPage = new WidgetsPage();

            Assert.IsTrue(widgetsPage.isPageOpen(), "Widgets page isn't open");

            widgetsPage.menuPage.OpenDatePickerForm();

            //Assert.IsTrue(.isPageOpen(), "Date picker form isn't open");

            log.Info("Step 3 completed successfully. Test case \"DatePicker\" completed.");
        }
    }
}
