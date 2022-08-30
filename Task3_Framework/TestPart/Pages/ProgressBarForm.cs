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
        private static Button startStopButton = new Button(By.XPath("//button[@id =\"startStopButton\"]"), "\"Start stop button\"");

        public ProgressBarForm() : base(progressBar = new ProgressBar(By.XPath("//div[@id =\"progressBar\"]"), "\"Progress bar\""), "\"Progress bar form\"")
        {
            locator = By.XPath("//div[@id =\"progressBar\"]");
            elementName = "\"Progress bar\"";
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