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
        private static Button addButton = new Button(By.XPath("//*[@id = \"addNewRecordButton\"]"), "\"button Add\"");
        private static Form regForm = new Form(By.XPath("//*[@id = \"userForm\"]"), "\"Registration form base element\"");
        private static string rowWithRegDataLocator = "//div[contains(text(), \"{0}\")]//parent:: div[contains(@class,\"rt-tr\")]";
        private static string deleteUserButtonLocator = "//div[contains(text(), \"{0}\")]//parent:: div[contains(@class,\"rt-tr\")]//following-sibling:: span[contains(@title, \"Delete\")]";
        private static By usersTableLocator = By.XPath("//div[@class = \"rt-td\"][contains(text(), \"@\")]");
        private static Header pageHeader = new Header(By.XPath("//div[@class = \"main-header\"]"), "\"Web tables page header\"");

        public RegistrationForm registrationForm = new RegistrationForm();

        public WebTablesForm() : base(webTablesFormButton = new Button(By.XPath(string.Format("//*[contains(text(), \"{0}\")]", ConfigUtils.TestData["WebTablesForm"])), "\"button webTables form\""), "\"Web tables form\"")
        {
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
