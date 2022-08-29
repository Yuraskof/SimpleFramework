using System;
using OpenQA.Selenium;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class ProgressBarForm : BasePage
    {
        private static ProgressBar progressBar;
        private static string progressBarName = "\"Progress bar\"";
        private static By progressBarLocator = By.XPath("//div[@id =\"progressBar\"]");
        private static string pageName = "\"Progress bar form\"";

        private static By startStopButtonLocator = By.XPath("//button[@id =\"startStopButton\"]");
        private static string startStopName = "\"Start stop button\"";
        private static Button startStopButton = new Button(startStopButtonLocator, startStopName);

        public ProgressBarForm() : base(progressBar = new ProgressBar(progressBarLocator, progressBarName), pageName)
        {
            locator = progressBarLocator;
            elementName = pageName;
        }

        public void SetProgressBarValue()
        {
            progressBar.JsScrollToElement();
            startStopButton.Click();

            while (true)
            {
                string progressBarValue = progressBar.SaveText();

                if (progressBarValue.Contains(ConfigUtils.TestData["Age"]))
                {
                    startStopButton.Click();
                    break;
                }
            }
        }

        public bool CompareResult()
        {
            decimal progressBarValue = StringUtil.ConvertToDecimal(progressBar.SaveText());
            decimal testDataValue = StringUtil.ConvertToDecimal(ConfigUtils.TestData["Age"]);
            
            return ValuesComparer.CompareDecimalsWithPrecission(progressBarValue, testDataValue, Convert.ToDecimal(ConfigUtils.TestData["PrecissionPercent"])); 
        }
    }
}