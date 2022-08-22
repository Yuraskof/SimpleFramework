using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class NestedFramesPage:BasePage
    {
        private By nestedFormsPageBaseElement = By.XPath("//*[@id=\"framesWrapper\"]");
        private string nestedFormsPageBaseElemenName = "\"Nested forms page\"";
        private By parentFrameElement = By.XPath("//*[@id=\"frame1\"]");
        private string parentFrameElemenName = "\"Parent frame\"";
        private By childFrameElement = By.XPath("//p[contains (text(), \"Child\")]");
        private string childFrameElemenName = "\"Child frame\"";


        public NestedFramesPage()
        {
            uniqueElement = nestedFormsPageBaseElement;
            name = nestedFormsPageBaseElemenName;
            NestedFramesPage mainPage = new NestedFramesPage(nestedFormsPageBaseElement, nestedFormsPageBaseElemenName);
        }

        public NestedFramesPage(By locator, string name) : base(locator, name)
        {

        }

        public string GetTextFromTheParentFrame()
        {
            IFrame frame = new IFrame(this.parentFrameElement, parentFrameElemenName);
            //frame.SwitchToFrame(this.parentFrameElement, parentFrameElemenName);
            return frame.SaveText(this.parentFrameElement, parentFrameElemenName);
        }

        public string GetTextFromTheChildFrame()
        {
            IFrame frame = new IFrame(this.childFrameElement, childFrameElemenName);
            frame.SwitchToFrame(this.childFrameElement, childFrameElemenName);
            return frame.SaveText(this.childFrameElement, childFrameElemenName);
        }
    }
}
