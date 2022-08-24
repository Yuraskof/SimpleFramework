using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class WebTablesForm:BasePage
    {
        private static Button webTablesFormButton;
        private static string webTablesFormButtonName = "\"button webTables form\"";
        private static By webTablesFormButtonLocator = By.XPath(string.Format("//*[contains(text(), \"{0}\")]", ConfigUtils.TestData["WebTablesForm"]));
        private static string pageName = "\"Web tables form\"";

        private static By addButtonLocator = By.XPath("//*[@id = \"addNewRecordButton\"]");
        private static string addButtonName = "\"button Add\"";
        private static Button addButton = new Button(addButtonLocator, addButtonName);

        private static By registrationFormLocator = By.XPath("//*[@id = \"userForm\"]");
        private static string registrationFormName = "\"Registration form base element\"";
        private static Form regForm = new Form(registrationFormLocator, registrationFormName);

        //private static By rowWithRegDataLocator = By.XPath(string.Format("//div[contains(text(), \"{0}\")]//parent:: div[contains(@class,\"rt-tr\")]", ConfigUtils.UserInfo["Email"]));
        //private static string rowWithRegDataName = "\"List with User info \"";
        //private static TextField rowWithRegData; //= new TextField(rowWithRegDataLocator, rowWithRegDataName);

        private static string rowWithRegDataLocator = "//div[contains(text(), \"{0}\")]//parent:: div[contains(@class,\"rt-tr\")]";
        private static string deleteUserButtonLocator = "//div[contains(text(), \"{0}\")]//parent:: div[contains(@class,\"rt-tr\")]//following-sibling:: span[contains(@title, \"Delete\")]";

        //private static By deleteUserButtonLocator = By.XPath(string.Format("//div[contains(text(), \"{0}\")]//parent:: div[contains(@class,\"rt-tr\")]//following-sibling:: span[contains(@title, \"Delete\")]", ConfigUtils.UserInfo["Email"]));
        //private static string deleteUserButtonName = "\"Delete user button\"";
        //private static Button deleteUserButton = new Button(deleteUserButtonLocator, deleteUserButtonName);

        private static By usersTableLocator = By.XPath("//div[@class = \"rt-td\"][contains(text(), \"@\")]");
        private static string usersTableName = "\"List with User info \"";
        private static Table usersTable = new Table(usersTableLocator, usersTableName);

        private static By pageHeaderLocator = By.XPath("//div[@class = \"main-header\"]");
        private static string pageHeaderName = "\"Web tables page header\"";
        private static Header pageHeader = new Header(pageHeaderLocator, pageHeaderName);


        public RegistrationForm registrationForm = new RegistrationForm();

        public WebTablesForm() : base(webTablesFormButton = new Button(webTablesFormButtonLocator, webTablesFormButtonName), pageName)
        {
            locator = webTablesFormButtonLocator;
            elementName = webTablesFormButtonName;
        }


        public void OpenRegistrationForm()
        {
            pageHeader.JsScrollToElement();
            pageHeader.IsEnabled();
            addButton.Click();
        }

        public bool CheckRegistrationFormIsClosed(WebDriverWait wait)
        {
            addButton.IsEnabled();
            return  regForm.IsDisplayed();
        }

        public string GetUserInfoFromTextFields()
        {
            TextField rowWithRegData = CreateRowWithRegDataTextField(rowWithRegDataLocator);
            rowWithRegData.IsEnabled();
            return rowWithRegData.SaveText();
        }

        private TextField CreateRowWithRegDataTextField(string locator)
        {
            locator = string.Format("//div[contains(text(), \"{0}\")]//parent:: div[contains(@class,\"rt-tr\")]", ConfigUtils.UserInfo["Email"]);
            By rowWithRegDataLocator = By.XPath(locator);
            TextField element = new TextField(rowWithRegDataLocator, "\"List with User info \"");
            return element;
        }

        public void DeleteUser()
        {
            Button deleteUserButton = CreateDeleteUserButton(deleteUserButtonLocator);
            deleteUserButton.Click();
        }

        private Button CreateDeleteUserButton(string locator)
        {
            locator = string.Format("//div[contains(text(), \"{0}\")]//parent:: div[contains(@class,\"rt-tr\")]//following-sibling:: span[contains(@title, \"Delete\")]", ConfigUtils.UserInfo["Email"]);
            By userButtonLocator = By.XPath(locator);
            Button element = new Button(userButtonLocator, "\"Delete user button\"");
            return element;
        }

        public bool CheckListIsChangeded()
        {
            int elementsListCount = DriverUtils.WebDriver.FindElements(usersTableLocator).Count;
            DeleteUser();
            int newElementsListCount = DriverUtils.WebDriver.FindElements(usersTableLocator).Count;
            return elementsListCount > newElementsListCount;
        }

        public bool CheckUserIsDeleted()
        {
            TextField rowWithRegData = CreateRowWithRegDataTextField(rowWithRegDataLocator);
            return rowWithRegData.IsDisplayed();
        }
    }
}
