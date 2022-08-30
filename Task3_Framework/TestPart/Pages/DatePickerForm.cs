using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Globalization;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.BaseClasses.Elements;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    internal class DatePickerForm:BasePage
    {
        private static DatePicker datePicker;

        private static By selectMonthLocator = By.XPath("//select[@class = \"react-datepicker__month-select\"]");
        private static string selectMonthName = "\"Select month dropdown\"";
        private static Dropdown selectMonthDropdown = new Dropdown(selectMonthLocator, selectMonthName);

        private static By selectYearLocator = By.XPath("//select[@class = \"react-datepicker__year-select\"]");
        private static string selectYearName = "\"Select year dropdown\"";
        private static Dropdown selectYearDropdown = new Dropdown(selectYearLocator, selectYearName);

        private static By dayButtonLocator = By.XPath(string.Format("//div[contains (text(), \"{0}\")]", ConfigUtils.TestData["Day"]));
        private static string dayButtonName = "\"Select day button\"";
        private static Button dayButton = new Button(dayButtonLocator, dayButtonName);

        private static By selectDateFieldLocator = By.XPath("//*[@id = \"datePickerMonthYearInput\"]");
        private static string selectDateFieldName = "\"Select date field\"";
        private static TextField selectDateField = new TextField(selectDateFieldLocator, selectDateFieldName);

        private static By dateAndTimeFieldLocator = By.XPath("//*[@id = \"dateAndTimePickerInput\"]");
        private static string dateAndTimeFieldName = "\"Date and time field\"";
        private static TextField dateAndTimeField = new TextField(dateAndTimeFieldLocator, dateAndTimeFieldName);

        
        public DatePickerForm() : base(datePicker = new DatePicker(By.XPath("//input[@id =\"datePickerMonthYearInput\"]"), "\"Date picker\""), "\"Date picker form\"")
        {
            locator = By.XPath("//input[@id =\"datePickerMonthYearInput\"]");
            elementName = "\"Date picker form\"";
        }

        public bool CompareDate()
        {
            DateTime now = DateTime.Now;
            string formatedDate = now.ToString("MM'/'dd'/'yyyy");
            string dateFromPage = selectDateField.GetAttribute("value");
            return StringUtil.CompareStrings(formatedDate, dateFromPage);
        }


        public bool CompareDateTime()
        {
            DateTime now = DateTime.Now;
            string formatedDateAndTime = now.ToString("MMMM dd, yyyy h:mm tt");
            string dateAndTimeFromPage = dateAndTimeField.GetAttribute("value");
            return StringUtil.CompareStrings(formatedDateAndTime, dateAndTimeFromPage);
        }

        public bool CompareClosestDate()
        {
            DateTime selectedDate = FindClosestDate();
            string formatedDate = selectedDate.ToString("MM'/'dd'/'yyyy");
            string dateFromPage = selectDateField.GetAttribute("value");
            return StringUtil.CompareStrings(formatedDate, dateFromPage);
        }

        public DateTime FindClosestDate()
        {
            selectDateField.Click();
            DateTime now = DateTime.Now;
            string currentYear = now.ToString("yyyy");
            DateTime dateInFuture = new DateTime();
            DateTime dateInPast = new DateTime();
            DateTime closestDate = new DateTime();

            IWebElement yearElement = DriverUtils.WebDriver.FindElement(selectYearLocator);
            var setYear = new SelectElement(yearElement);
            setYear.SelectByValue(currentYear);

            IWebElement monthElement = DriverUtils.WebDriver.FindElement(selectMonthLocator);
            var selectMonth = new SelectElement(monthElement);
            selectMonth.SelectByText(ConfigUtils.TestData["Month"]);

            int selectedYear = now.Year;
            int month = Array.FindIndex(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames,
                t => t.Equals(ConfigUtils.TestData["Month"], StringComparison.CurrentCultureIgnoreCase))+1;
            
            DriverUtils.SetImplicitWait(1);

            for (int i = selectedYear; i > 0; selectedYear++)
            {
                setYear.SelectByValue(Convert.ToString(selectedYear));

                if (dayButton.ElementIsPresent())
                {
                    var elements = dayButton.GetListOfElements();

                    foreach (var element in elements)
                    {
                        string attribute = element.GetAttribute("aria-label");

                        if (attribute.Contains(ConfigUtils.TestData["Month"]) && attribute.Contains(ConfigUtils.TestData["Day"]))
                        {
                            dayButton.JsScrollToElement();
                            element.Click();
                            dateInFuture = new DateTime(selectedYear, month, Convert.ToInt32(ConfigUtils.TestData["Day"]));
                            closestDate = dateInFuture;
                            i = -1;
                            break;
                        }
                    }
                }
            }

            TimeSpan differenceNowFuture = dateInFuture.Subtract(now);
            
            selectDateField.Click();
            yearElement = DriverUtils.WebDriver.FindElement(selectYearLocator);
            setYear = new SelectElement(yearElement);
            monthElement = DriverUtils.WebDriver.FindElement(selectMonthLocator);
            selectMonth = new SelectElement(monthElement);
            selectedYear = now.Year - 1;

            for (int i = selectedYear; i > 0; selectedYear--)
            {
                setYear.SelectByValue(Convert.ToString(selectedYear));
                selectMonth.SelectByText(ConfigUtils.TestData["Month"]);

                if (dayButton.ElementIsPresent())
                {
                    var elements = dayButton.GetListOfElements();

                    foreach (var element in elements)
                    {
                        string attribute = element.GetAttribute("aria-label");

                        if (attribute.Contains(ConfigUtils.TestData["Month"]) && attribute.Contains(ConfigUtils.TestData["Day"]))
                        {
                            dateInPast = new DateTime(selectedYear, month, Convert.ToInt32(ConfigUtils.TestData["Day"]));
                            TimeSpan differenceNowPast = now.Subtract(dateInPast);

                            if (differenceNowPast<differenceNowFuture)
                            {
                                dayButton.JsScrollToElement();
                                element.Click();
                                closestDate = dateInPast;
                            }
                            i = -1;
                            break;
                        }
                    }
                }
            }
            DriverUtils.SetImplicitWait(Convert.ToInt32(DriverUtils.BrowserConfig["wait_time"]));
            return closestDate;
        }


    }
}
