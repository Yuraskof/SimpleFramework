using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;

namespace Task3_Framework.TestPart.Pages
{
    class ElementsPage:BasePage
    {
        private By elementsPageBaseElement = By.XPath(string.Format("//div[contains(@class, \"show\")]//span[contains(text(), \"{0}\")]", ConfigUtils.TestData["ElementsWindows"]));
        private string pageName = "\"Elements page\"";

        public MenuPage menuPage = new MenuPage();

        public ElementsPage()
        {
            uniqueElement = elementsPageBaseElement;
            name = pageName;
            ElementsPage elementsPage = new ElementsPage(elementsPageBaseElement, pageName);
        }

        public ElementsPage(By locator, string name) : base(locator, name)
        {

        }
    }
}
