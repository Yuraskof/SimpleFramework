using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class WebTablesForm:BasePage
    {
        private By webTablesFormUniqueElement = By.XPath(string.Format("//*[contains(text(), \"{0}\")]", ConfigUtils.TestData["WebTablesForm"]));
        private string pageName = "\"Web tables form\"";
        private By addButtonElement = By.XPath("//*[@id = \"addNewRecordButton\"]");
        private string addButtonName = "\"button Add\"";
        private By registrationFormBaseElement = By.XPath("//*[@id = \"userForm\"]");
        private string registrationFormBaseElementName = "\"Registration form base element\"";

        public RegistrationForm registrationForm = new RegistrationForm();

        public WebTablesForm()
        {
            uniqueElement = webTablesFormUniqueElement;
            name = pageName;
            WebTablesForm webTablesForm = new WebTablesForm(webTablesFormUniqueElement, pageName);
        }



        public WebTablesForm(By locator, string name) : base(locator, name)
        {

        }

        public void OpenRegistrationForm()
        {
            Button addButton = new Button(addButtonElement, addButtonName);
            addButton.Click(addButtonElement, addButtonName);
        }

        public bool CheckRegistrationFormIsClosed(WebDriverWait wait)
        {
            Button addButton = new Button(addButtonElement, addButtonName);
            addButton.IsEnabled(addButtonElement, addButtonName);

            TextField firstName = new TextField(registrationFormBaseElement, registrationFormBaseElementName);
            return  firstName.IsDisplayed(registrationFormBaseElement, registrationFormBaseElementName, wait);
        }
    }
}
