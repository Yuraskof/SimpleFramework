using System.Collections.Generic;
using NUnit.Framework;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.Pages;

namespace Task3_Framework.TestPart.Tests
{
    class TestCase3Tables:BaseTest
    {
        [Test]
        [TestCaseSource("GetTestItems")]
        public void CheckTables(UserModel model)
        {
            log.Info("Test case \"Tables\" started.");

            BrowserUtils.GoToUrl(DriverUtils.BrowserConfig["baseUrl"]);

            MainPage mainPage = new MainPage();

            Assert.IsTrue(mainPage.isPageOpen(), "Main page isn't open");

            log.Info("Step 1 completed successfully");

            mainPage.GoToElementsPage();

            ElementsPage elementsPage = new ElementsPage();

            elementsPage.menuPage.OpenWebTablesForm();

            WebTablesForm webTablesForm = new WebTablesForm();

            Assert.IsTrue(webTablesForm.isPageOpen(), "Web tables form form isn't open");

            log.Info("Step 2 completed successfully");

            webTablesForm.OpenRegistrationForm();

            Assert.IsTrue(webTablesForm.registrationForm.isPageOpen(), "Registration form form isn't open");

            log.Info("Step 3 completed successfully");

            webTablesForm.registrationForm.FillRegistrationForm(model);

            webTablesForm.registrationForm.SubmitForm();

            DriverUtils.SetImplicitWait(0);

            Assert.IsTrue(webTablesForm.CheckRegistrationFormIsClosed(DriverUtils.wait), "Registration form is open");

            DriverUtils.SetImplicitWait(10);

            UserModel userModelFromPage = new UserModel();

            string userInfo = webTablesForm.GetUserInfoFromTextFields(model.Email);

            userModelFromPage.SetUserModelFromTextFields(userInfo);

            Assert.IsTrue(userModelFromPage.Equals(model), "Models are not equal");

            log.Info("Step 4 completed successfully");

            Assert.IsTrue(webTablesForm.CheckListIsChangeded(model.Email), "List not changed");

            DriverUtils.SetImplicitWait(0);

            Assert.IsTrue(webTablesForm.CheckUserIsDeleted(model.Email), "User not deleted");

            log.Info("Step 5 completed successfully. Test case \"Tables\" completed.");
        }

        public static IEnumerable<object[]> GetTestItems()
        {
            ConfigUtils.GetTestData();
            yield return new [] { UserModel.CreateModel("User1") };
            yield return new [] { UserModel.CreateModel("User2") };
        }
    }
}
