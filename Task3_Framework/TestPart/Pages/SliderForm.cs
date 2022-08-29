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
        private static string sliderName = "\"Slider\"";
        private static By sliderLocator = By.XPath("//input[contains(@class, \"range-slider\")]"); 
        private static string pageName = "\"Slider form\"";
        private static By sliderTextFieldLocator = By.XPath("//input[@id= \"sliderValue\"]");
        private static string sliderTextFieldName = "\"Slider text field\"";
        private static TextField sliderTextField = new TextField(sliderTextFieldLocator, sliderTextFieldName);

        public SliderForm() : base(slider = new Slider(sliderLocator, sliderName), pageName)
        {
            locator = sliderLocator;
            elementName = sliderName;
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
