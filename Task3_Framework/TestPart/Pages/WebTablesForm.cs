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
        private static By addButtonLocator = By.XPath("//*[@id = \"addNewRecordButton\"]");
        private static string addButtonName = "\"button Add\"";
        private static Button addButton = new Button(addButtonLocator, addButtonName);
        private static By registrationFormLocator = By.XPath("//*[@id = \"userForm\"]");
        private static string registrationFormName = "\"Registration form base element\"";
        private static Form regForm = new Form(registrationFormLocator, registrationFormName);
        private static string rowWithRegDataLocator = "//div[contains(text(), \"{0}\")]//parent:: div[contains(@class,\"rt-tr\")]";
        private static string deleteUserButtonLocator = "//div[contains(text(), \"{0}\")]//parent:: div[contains(@class,\"rt-tr\")]//following-sibling:: span[contains(@title, \"Delete\")]";
        private static By usersTableLocator = By.XPath("//div[@class = \"rt-td\"][contains(text(), \"@\")]");
        private static string usersTableName = "\"List with User info \"";
        private static Table usersTable = new Table(usersTableLocator, usersTableName);
        private static By pageHeaderLocator = By.XPath("//div[@class = \"main-header\"]");
        private static string pageHeaderName = "\"Web tables page header\"";
        private static Header pageHeader = new Header(pageHeaderLocator, pageHeaderName);


        public RegistrationForm registrationForm = new RegistrationForm();

        public WebTablesForm() : base(webTablesFormButton = new Button(By.XPath(string.Format("//*[contains(text(), \"{0}\")]", ConfigUtils.TestData["WebTablesForm"])), "\"button webTables form\""), "\"Web tables form\"")
        {
            locator = By.XPath(string.Format("//*[contains(text(), \"{0}\")]", ConfigUtils.TestData["WebTablesForm"]));
            elementName = "\"button webTables form\"";
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

        public string GetUserInfoFromTextFields(string uniqueText)
        {
            TextField rowWithRegData = CreateRowWithRegDataTextField(rowWithRegDataLocator, uniqueText);
            rowWithRegData.IsEnabled();
            return rowWithRegData.SaveText();
        }

        private TextField CreateRowWithRegDataTextField(string locator, string uniqueText)
        {
            locator = string.Format("//div[contains(text(), \"{0}\")]//parent:: div[contains(@class,\"rt-tr\")]", uniqueText);
            By rowWithRegDataLocator = By.XPath(locator);
            TextField element = new TextField(rowWithRegDataLocator, "\"List with User info \"");
            return element;
        }

        public void DeleteUser(string uniqueText)
        {
            Button deleteUserButton = CreateDeleteUserButton(deleteUserButtonLocator, uniqueText);
            deleteUserButton.Click();
        }

        private Button CreateDeleteUserButton(string locator, string uniqueText)
        {
            locator = string.Format("//div[contains(text(), \"{0}\")]//parent:: div[contains(@class,\"rt-tr\")]//following-sibling:: span[contains(@title, \"Delete\")]", uniqueText);
            By userButtonLocator = By.XPath(locator);
            Button element = new Button(userButtonLocator, "\"Delete user button\"");
            return element;
        }

        public bool CheckListIsChangeded(string uniqueText)
        {
            int elementsListCount = DriverUtils.WebDriver.FindElements(usersTableLocator).Count;
            DeleteUser(uniqueText);
            int newElementsListCount = DriverUtils.WebDriver.FindElements(usersTableLocator).Count;
            return elementsListCount > newElementsListCount;
        }

        public bool CheckUserIsDeleted(string uniqueText)
        {
            TextField rowWithRegData = CreateRowWithRegDataTextField(rowWithRegDataLocator, uniqueText);
            return rowWithRegData.IsDisplayed();
        }
    }
}
