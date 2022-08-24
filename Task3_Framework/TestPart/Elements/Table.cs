using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;

namespace Task3_Framework.TestPart
{
    class Table:BaseElement
    {
        public Table(By locator, string name) : base(locator, name)
        {

        }
    }
}
