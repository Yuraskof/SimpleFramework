using System;
using System.Collections.Generic;
using System.Text;
using Task2_SeleniumWebDriver.Steam.FrameworkPart;

namespace Task3_Framework.FrameworkPart.UtilClasses
{
    class BrowserUtils
    {
        public static void GoToUrl(string url)
        {
            DriverUtils.WebDriver.Url = url;
        }
    }
}
