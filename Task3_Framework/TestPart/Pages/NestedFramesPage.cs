using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;

namespace Task3_Framework.TestPart.Pages
{
    class NestedFramesPage:BasePage
    {
        private By nestedFormsPageBaseElement = By.XPath("//*[@id=\"framesWrapper\"]");
        private string nestedFormsPageBaseElemenName = "\"Nested forms page\"";


        public NestedFramesPage()
        {
            uniqueElement = nestedFormsPageBaseElement;
            name = nestedFormsPageBaseElemenName;
            NestedFramesPage mainPage = new NestedFramesPage(nestedFormsPageBaseElement, nestedFormsPageBaseElemenName);
        }

        public NestedFramesPage(By locator, string name) : base(locator, name)
        {

        }
    }
}
