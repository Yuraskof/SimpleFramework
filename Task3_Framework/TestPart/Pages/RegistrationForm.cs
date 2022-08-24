using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class RegistrationForm:BasePage
    {
        private static Form regForm;
        private static string registrationFormName = "\"Registration form base element\"";
        private static By registrationFormLocator = By.XPath("//*[@id = \"userForm\"]");
        private static string pageName = "\"Registration form\"";

        private static By firstNameTextFieldLocator = By.XPath("//*[@id = \"firstName\"]");
        private static string firstNameTextFieldName = "\"First name text field\"";
        private static TextField firstNameTextField = new TextField(firstNameTextFieldLocator, firstNameTextFieldName);

        private static By lastNameTextFieldLocator = By.XPath("//*[@id = \"lastName\"]");
        private static string lastNameTextFieldName = "\"Last name text field\"";
        private static TextField lastNameTextField = new TextField(lastNameTextFieldLocator, lastNameTextFieldName);

        private static By emailTextFieldLocator = By.XPath("//*[@id = \"userEmail\"]");
        private static string emailTextFieldName = "\"Email text field\"";
        private static TextField emailTextField = new TextField(emailTextFieldLocator, emailTextFieldName);

        private static By ageTextFieldLocator = By.XPath("//*[@id = \"age\"]");
        private static string ageTextFieldName = "\"Age text field\"";
        private static TextField ageTextField = new TextField(ageTextFieldLocator, ageTextFieldName);

        private static By salaryTextFieldLocator = By.XPath("//*[@id = \"salary\"]");
        private static string salaryTextFieldName = "\"Salary text field\"";
        private static TextField salaryTextField = new TextField(salaryTextFieldLocator, salaryTextFieldName);

        private static By departmentTextFieldLocator = By.XPath("//*[@id = \"department\"]");
        private static string departmentTextFieldName = "\"Department text field\"";
        private static TextField departmentTextField = new TextField(departmentTextFieldLocator, departmentTextFieldName);

        private static By submitButtonLocator = By.XPath("//*[@id = \"submit\"]");
        private static string submitButtonName = "\"Submit button\"";
        private static Button submitButton = new Button(submitButtonLocator, submitButtonName);


        public RegistrationForm() : base(regForm = new Form(registrationFormLocator, registrationFormName), pageName)
        {
            locator = registrationFormLocator;
            elementName = registrationFormName;
        }
        
        public void FillRegistrationForm(UserModel model)
        {
            firstNameTextField.SendKeys(model.FirstName);
            lastNameTextField.SendKeys(model.LastName);
            emailTextField.SendKeys(model.Email);
            ageTextField.SendKeys(model.Age);
            salaryTextField.SendKeys(model.Salary);
            departmentTextField.SendKeys(model.Department);
        }

        public void SubmitForm()
        {
            submitButton.Click();
        }
    }
}
