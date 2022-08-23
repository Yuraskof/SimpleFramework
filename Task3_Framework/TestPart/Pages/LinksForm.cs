using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class LinksForm:BasePage
    {
        private By linksFormBaseElement = By.XPath("//*[@id = \"linkWrapper\"]");
        private string linksFormBaseName = "\"links form\"";
        private By homeReferenceElement = By.XPath("//*[@id = \"simpleLink\"]");
        private string homeReferenceElementName = "\"Home reference\"";

        public LinksForm()
        {
            uniqueElement = linksFormBaseElement;
            name = linksFormBaseName;
            LinksForm linksForm = new LinksForm(linksFormBaseElement, linksFormBaseName);
        }

        public LinksForm(By locator, string name) : base(locator, name)
        {

        }

        public void OpenHomeReference()
        {
            Button button = new Button(homeReferenceElement, homeReferenceElementName);
            button.Click(homeReferenceElement, homeReferenceElementName);
        }
    }
}
