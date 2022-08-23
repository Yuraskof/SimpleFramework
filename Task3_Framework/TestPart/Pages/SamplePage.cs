using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;

namespace Task3_Framework.TestPart.Pages
{
    class SamplePage:BasePage
    {
        private By samplePageBaseElement = By.XPath("//*[@id =\"sampleHeading\"]");
        private string samplePageBaseElementName = "\"Sample page\"";

        public SamplePage()
        {
            uniqueElement = samplePageBaseElement;
            name = samplePageBaseElementName;
            SamplePage samplePage = new SamplePage(samplePageBaseElement, samplePageBaseElementName);
        }

        public SamplePage(By locator, string name) : base(locator, name)
        {

        }
    }
}
