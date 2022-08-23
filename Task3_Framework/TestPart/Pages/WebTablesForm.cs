using System;
using System.Collections.Generic;
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
        private By rowWithRegData = By.XPath(string.Format("//div[contains(text(), \"{0}\")]//parent:: div[contains(@class,\"rt-tr\")]", ConfigUtils.UserInfo["Email"]));
        private string rowWithRegDataName = "\"List with User info \"";
        private By deleteUserButtonElement = By.XPath(string.Format("//div[contains(text(), \"{0}\")]//parent:: div[contains(@class,\"rt-tr\")]//following-sibling:: span[contains(@title, \"Delete\")]", ConfigUtils.UserInfo["Email"]));
        private string deleteUserButtonName = "\"Delete user button\"";
        private By usersTable = By.XPath("//div[@class = \"rt-td\"][contains(text(), \"@\")]");
        
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

        public string GetUserInfoFromTextFields()
        {
            TextField userInfo = new TextField(rowWithRegData, rowWithRegDataName);
            return userInfo.SaveText(rowWithRegData, rowWithRegDataName);
        }

        public void DeleteUser()
        {
            Button closeButton = new Button(deleteUserButtonElement, deleteUserButtonName);
            closeButton.Click(deleteUserButtonElement, deleteUserButtonName);
        }

        public bool CheckListIsChangeded()
        {
            int elementsListCount = DriverUtils.WebDriver.FindElements(usersTable).Count;
            DeleteUser();
            int newElementsListCount = DriverUtils.WebDriver.FindElements(usersTable).Count;
            return elementsListCount > newElementsListCount;
        }

        public bool CheckUserIsDeleted(WebDriverWait wait)
        {
            TextField userInfo = new TextField(rowWithRegData, rowWithRegDataName);
            bool isNotDisplayed = userInfo.IsDisplayed(rowWithRegData, rowWithRegDataName, wait);
            return  isNotDisplayed == true;
        }
    }
}
