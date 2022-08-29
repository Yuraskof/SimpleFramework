using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Task3_Framework.FrameworkPart.UtilClasses;
using Task3_Framework.TestPart.BaseClasses;
using Task3_Framework.TestPart.Elements;

namespace Task3_Framework.TestPart.Pages
{
    class SliderForm:BasePage
    {
        private static Slider slider;
        private static By sliderTextFieldLocator = By.XPath("//input[@id= \"sliderValue\"]");
        private static string sliderTextFieldName = "\"Slider text field\"";
        private static TextField sliderTextField = new TextField(sliderTextFieldLocator, sliderTextFieldName);

        public SliderForm() : base(slider = new Slider(By.XPath("//input[contains(@class, \"range-slider\")]"), "\"Slider\""), "\"Slider form\"")
        {
            locator = By.XPath("//input[contains(@class, \"range-slider\")]");
            elementName = "\"Slider\"";
        }

        public int SetSliderValue()
        {
            List<int> minMaxValues = slider.GetMaxMinValues();
            int sliderValue = RandomIntGenerator.GenerateRandomInt(minMaxValues);
            slider.MoveSlider(sliderValue, minMaxValues);
            return sliderValue;
        }

        public int CompareSliderValue()
        {
            return Convert.ToInt32(sliderTextField.GetAttribute("value"));
        }
    }
}
