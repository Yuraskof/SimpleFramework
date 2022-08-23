using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;

namespace Task3_Framework.TestPart.Pages
{
    class FramesForm:BasePage
    {
        private By framesFormsBaseElement = By.XPath("//*[@id=\"framesWrapper1\"]");
        private string framesFormsBaseElementName = "\"Frames form\"";

        public HighFrame highFrame = new HighFrame();
        public LowFrame lowFrame = new LowFrame();

        public FramesForm()
        {
            uniqueElement = framesFormsBaseElement;
            name = framesFormsBaseElementName;
            FramesForm framesPage = new FramesForm(framesFormsBaseElement, framesFormsBaseElementName);
        }

        public FramesForm(By locator, string name) : base(locator, name)
        {

        }
    }
}
