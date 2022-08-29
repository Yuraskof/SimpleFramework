using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Task3_Framework.TestPart.BaseClasses;

namespace Task3_Framework.TestPart.Elements
{
    class Slider:BaseElement
    {
        public Slider(By locator, string name) : base(locator, name)
        {

        }

        public List<int> GetMaxMinValues()
        {
            List<int> maxMinValues = new List<int>();
            IWebElement element = Find();
            int minValue = Int32.Parse(element.GetAttribute("min"));
            maxMinValues.Add(minValue);
            int maxValue = Int32.Parse(element.GetAttribute("max"));
            maxMinValues.Add(maxValue);
            return maxMinValues;
        }


        public void MoveSlider(int value, List<int> minMaxValues)
        {
            IWebElement element = Find();

            Actions move = new Actions(DriverUtils.WebDriver);

            element.Click();

            int difference = Math.Abs((minMaxValues[1]-minMaxValues[0])/2 - value);

            if (value > 50)
            {
                move.ClickAndHold(element);

                for (int i = 0; i < difference; i++)
                {
                    move.SendKeys(Keys.ArrowUp);
                }
                move.Release().Build().Perform();
            }
            else if(value < 50)
            {
                move.ClickAndHold(element);

                for (int i = 0; i < difference; i++)
                {
                    move.SendKeys(Keys.ArrowDown);
                }
                move.Release().Build().Perform();
            }

            log.Info(string.Format("{1} value = {0} ", value, uniqueName));
        }
    }
}
