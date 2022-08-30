using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class RegistrationForm:BasePage
    {
        private static Form regForm;
        private static TextField firstNameTextField = new TextField(By.XPath("//*[@id = \"firstName\"]"), "\"First name text field\"");
        private static TextField lastNameTextField = new TextField(By.XPath("//*[@id = \"lastName\"]"), "\"Last name text field\"");
        private static TextField emailTextField = new TextField(By.XPath("//*[@id = \"userEmail\"]"), "\"Email text field\"");
        private static TextField ageTextField = new TextField(By.XPath("//*[@id = \"age\"]"), "\"Age text field\"");
        private static TextField salaryTextField = new TextField(By.XPath("//*[@id = \"salary\"]"), "\"Salary text field\"");
        private static TextField departmentTextField = new TextField(By.XPath("//*[@id = \"department\"]"), "\"Department text field\"");
        private static Button submitButton = new Button(By.XPath("//*[@id = \"submit\"]"), "\"Submit button\"");
        
        public RegistrationForm() : base(regForm = new Form(By.XPath("//*[@id = \"userForm\"]"), "\"Registration form base element\""), "\"Registration form\"")
        {
            locator = By.XPath("//*[@id = \"userForm\"]");
            elementName = "\"Registration form base element\"";
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
