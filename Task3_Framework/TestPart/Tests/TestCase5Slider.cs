using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.Pages;

namespace Task3_Framework.TestPart.Tests
{
    class TestCase5Slider:BaseTest
    {
        [Test]
        public void CheckSliderAndProgressBar()
        {
            log.Info("Test case \"Slider\" started.");

            BrowserUtils.GoToUrl(DriverUtils.BrowserConfig["baseUrl"]);

            MainPage mainPage = new MainPage();

            Assert.IsTrue(mainPage.isPageOpen(), "Main page isn't open");

            log.Info("Step 1 completed successfully");

            mainPage.GoToWidgetsPage();

            WidgetsPage widgetsPage = new WidgetsPage();

            Assert.IsTrue(widgetsPage.isPageOpen(), "Widgets page isn't open");

            widgetsPage.menuPage.OpenSliderForm();

            SliderForm sliderForm = new SliderForm();

            Assert.IsTrue(sliderForm.isPageOpen(), "Slider form isn't open");

            log.Info("Step 2 completed successfully");

            Assert.AreEqual(sliderForm.SetSliderValue(), sliderForm.CompareSliderValue(), "Values are not equal");

            log.Info("Step 3 completed successfully");

            widgetsPage.menuPage.OpenProgressBarForm();

            ProgressBarForm progressBarForm = new ProgressBarForm();

            Assert.IsTrue(progressBarForm.isPageOpen(), "Progress bar form isn't open");

            log.Info("Step 4 completed successfully");

            progressBarForm.SetProgressBarValue();

            log.Info("Step 5 completed successfully");

            Assert.IsTrue(progressBarForm.CompareResult(), "Values are not equal");

            log.Info("Step 6 completed successfully. Test case \"Slider\" completed.");
        }
    }
}
