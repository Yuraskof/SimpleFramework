using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Task3_Framework.TestPart.BaseClasses;

namespace Task3_Framework.TestPart.Elements
{
    internal class DatePicker:BaseElement
    {
        public DatePicker(By locator, string name) : base(locator, name)
        {

        }
    }
}
