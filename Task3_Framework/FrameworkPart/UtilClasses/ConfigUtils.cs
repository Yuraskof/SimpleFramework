using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Task2_SeleniumWebDriver.Steam.FrameworkPart.BrowserUtils
{
    public static class ConfigUtils
    {
        public static Dictionary<string, string> TestData = new Dictionary<string, string>();

        public static void GetTestData()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData.json");
            var json = File.ReadAllText(filePath);
            var jsonObj = JObject.Parse(json);

            foreach (var element in jsonObj)
            { 
                TestData.Add(element.Key, element.Value.ToString());
            }
        }


        public static void GetBrowserConfig()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
            var json = File.ReadAllText(filePath);
            var jsonObj = JObject.Parse(json);

            foreach (var element in jsonObj)
            {
                DriverUtils.BrowserConfig.Add(element.Key, element.Value.ToString());
            }
        }
    }
}
