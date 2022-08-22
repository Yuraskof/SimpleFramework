using System;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.Pages;

namespace Task3_Framework.TestPart.Tests
{
    class TestCase3Tables:BaseTest
    {
        [Test]
        [TestCase("User1")]
        [TestCase("User2")]
        public void CheckTables(string configKey)
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

            ConfigUtils.GetUserInfo(configKey);

            UserModel userModelFromTestData = new UserModel();

            userModelFromTestData.SetModelFieldsFromTestData();

            webTablesForm.OpenRegistrationForm();

            webTablesForm.registrationForm.FillRegistrationForm(userModelFromTestData);

            webTablesForm.registrationForm.SubmitForm();

            DriverUtils.SetImplicitWait(0);

            WebDriverWait wait = new WebDriverWait(DriverUtils.WebDriver, TimeSpan.FromSeconds(10));

            Assert.IsTrue(webTablesForm.CheckRegistrationFormIsClosed(wait), "Registration form is open"); 


            log.Info("Test case \"Tables\" completed.");
        }
    }
}
