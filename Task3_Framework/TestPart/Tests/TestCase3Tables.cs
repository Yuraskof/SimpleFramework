using System;
using System.Collections.Generic;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
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

            ConfigUtils.GetUserInfo(configKey);

            MainPage mainPage = new MainPage();

            Assert.IsTrue(mainPage.isPageOpen(), "Main page isn't open");

            log.Info("Step 1 completed successfully");

            mainPage.GoToElementsPage();

            ElementsPage elementsPage = new ElementsPage();

            elementsPage.menuPage.OpenWebTablesForm();

            WebTablesForm webTablesForm = new WebTablesForm();

            Assert.IsTrue(webTablesForm.isPageOpen(), "Web tables form form isn't open");

            log.Info("Step 2 completed successfully");

            UserModel userModelFromTestData = new UserModel();

            userModelFromTestData.SetModelFieldsFromTestData();

            webTablesForm.OpenRegistrationForm();

            Assert.IsTrue(webTablesForm.registrationForm.isPageOpen(), "Registration form form isn't open");

            log.Info("Step 3 completed successfully");

            webTablesForm.registrationForm.FillRegistrationForm(userModelFromTestData);

            webTablesForm.registrationForm.SubmitForm();

            DriverUtils.SetImplicitWait(0);

            WebDriverWait wait = new WebDriverWait(DriverUtils.WebDriver, TimeSpan.FromSeconds(10));

            Assert.IsTrue(webTablesForm.CheckRegistrationFormIsClosed(wait), "Registration form is open");

            DriverUtils.SetImplicitWait(10);

            UserModel userModelFromPage = new UserModel();

            string userInfo = webTablesForm.GetUserInfoFromTextFields();

            userModelFromPage.SetUserModelFromTextFields(userInfo);

            Assert.IsTrue(userModelFromPage.Equals(userModelFromTestData), "Models are not equal");

            log.Info("Step 4 completed successfully");

            Assert.IsTrue(webTablesForm.CheckListIsChangeded(), "List not changed"); 

            DriverUtils.SetImplicitWait(0);

            Assert.IsTrue(webTablesForm.CheckUserIsDeleted(wait), "User not deleted"); 

            log.Info("Step 5 completed successfully. Test case \"Tables\" completed.");
        }
    }
}
