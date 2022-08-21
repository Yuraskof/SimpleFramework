using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;

namespace Task3_Framework.TestPart.Elements
{
    class TextField:BaseElement
    {
        public TextField(By locator, string name) : base(locator, name)
        {

        }
    }
}
