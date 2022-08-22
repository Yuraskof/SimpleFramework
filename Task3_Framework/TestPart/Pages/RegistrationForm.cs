using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class RegistrationForm:BasePage
    {
        private By registrationFormBaseElement = By.XPath("//*[@id = \"userForm\"]");
        private string pageName = "\"Registration form\"";
        private By firstNameTextField = By.XPath("//*[@id = \"firstName\"]");
        private string firstNameTextFieldName = "\"First name text field\"";
        private By lastNameTextField = By.XPath("//*[@id = \"lastName\"]");
        private string lastNameTextFieldName = "\"Last name text field\"";
        private By emailTextField = By.XPath("//*[@id = \"userEmail\"]");
        private string emailTextFieldName = "\"Email text field\"";
        private By ageTextField = By.XPath("//*[@id = \"age\"]");
        private string ageTextFieldName = "\"Age text field\"";
        private By salaryTextField = By.XPath("//*[@id = \"salary\"]");
        private string salaryTextFieldName = "\"Salary text field\"";
        private By departmentTextField = By.XPath("//*[@id = \"department\"]");
        private string departmentTextFieldName = "\"Department text field\"";
        private By submitButton = By.XPath("//*[@id = \"submit\"]");
        private string submitButtonName = "\"Submit button\"";



        public RegistrationForm()
        {
            uniqueElement = registrationFormBaseElement;
            name = pageName;
            RegistrationForm elementsPage = new RegistrationForm(registrationFormBaseElement, pageName);
        }

        public RegistrationForm(By locator, string name) : base(locator, name)
        {

        }

        public void FillRegistrationForm(UserModel model)
        {
            TextField firstName = new TextField(this.firstNameTextField, firstNameTextFieldName);
            firstName.SendKeys(model.FirstName, firstNameTextField, firstNameTextFieldName);

            TextField lastName = new TextField(this.lastNameTextField, lastNameTextFieldName);
            firstName.SendKeys(model.LastName, lastNameTextField, lastNameTextFieldName);

            TextField email = new TextField(this.emailTextField, emailTextFieldName);
            firstName.SendKeys(model.Email, emailTextField, emailTextFieldName);

            TextField age = new TextField(this.ageTextField, ageTextFieldName);
            firstName.SendKeys(model.Age, ageTextField, ageTextFieldName);

            TextField salary = new TextField(this.salaryTextField, salaryTextFieldName);
            firstName.SendKeys(model.Salary, salaryTextField, salaryTextFieldName);

            TextField department = new TextField(this.departmentTextField, departmentTextFieldName);
            firstName.SendKeys(model.Department, departmentTextField, departmentTextFieldName);
        }

        public void SubmitForm()
        {
            Button submitButton = new Button(this.submitButton, submitButtonName);
            submitButton.Click(this.submitButton, submitButtonName);
        }
    }
}
