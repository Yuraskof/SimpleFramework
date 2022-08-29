using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    internal class DatePickerForm:BasePage
    {
        private static DatePicker datePicker;
        private static string datePickerName = "\"Date picker\"";
        private static By datePickerLocator = By.XPath("//input[@id =\"datePickerMonthYearInput\"]");
        private static string pageName = "\"Date picker form\"";

        private static By selectMonthLocator = By.XPath("//select[@class = \"react-datepicker__month-select\"]");
        private static string selectMonthName = "\"Select month dropdown\"";
        private static Dropdown selectMonthDropdown = new Dropdown(selectMonthLocator, selectMonthName);

        private static By selectYearLocator = By.XPath("//select[@class = \"react-datepicker__year-select\"]");
        private static string selectYearName = "\"Select year dropdown\"";
        private static Dropdown selectYearDropdown = new Dropdown(selectYearLocator, selectYearName);

        private static By dayButtonLocator = By.XPath("//div[contains (text(), \"29\")]"); //testData
        private static string dayButtonName = "\"Start stop button\"";
        private static Button dayButton = new Button(dayButtonLocator, dayButtonName);

        //private static By startStopButtonLocator = By.XPath("//button[contains (text(), \"Previous Month\")]");
        //private static string startStopName = "\"Start stop button\"";
        //private static Button startStopButton = new Button(startStopButtonLocator, startStopName);

        public DatePickerForm() : base(datePicker = new DatePicker(datePickerLocator, datePickerName), pageName)
        {
            locator = datePickerLocator;
            elementName = pageName;
        }

        public void CompareDateTime()
        {
            // 08/26/2022
            // August 26, 2022 9:14 PM

            DateTime now = DateTime.Now;
            string formatedDateAndTime = now.ToString("MMMM dd, yyyy h:mm tt");
            string formatedDate = now.ToString("d");


            IWebElement selectElement = DriverUtils.WebDriver.FindElement(By.Id("selectElementID"));
            var selectObject = new SelectElement(selectElement);

            selectObject.SelectByValue("value1");
            // Select an <option> based upon its text
            selectObject.SelectByText("Bread");


            DateTime dateInPast = new DateTime(2015, 7, 20); // 20.07.2015 18:30:25
            DateTime dateInFuture = new DateTime(2015, 7, 20); // 20.07.2015 15:30:25
            DateTime dateNow = DateTime.Today;


           // Console.WriteLine(date1.Subtract(date2)); // 03:00:00

        }
    }
}
