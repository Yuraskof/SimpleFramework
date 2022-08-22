using OpenQA.Selenium;
using Task3_Framework.TestPart.BaseClasses;

namespace Task3_Framework.TestPart.Elements
{
    class TextField:BaseElement
    {
        public TextField(By locator, string name) : base(locator, name)
        {

        }

        public void SendKeys(string textToSend, By locator, string name)
        {
            Find(locator, name).SendKeys(textToSend);
            log.Info(string.Format("send text = \"{1}\" to element {0} ", name, textToSend));
        }
    }
}
