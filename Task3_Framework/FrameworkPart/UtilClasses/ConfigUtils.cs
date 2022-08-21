using System;
using System.Collections.Generic;
using System.IO;
using log4net;
using Newtonsoft.Json.Linq;

namespace Task3_Framework
{
    public static class ConfigUtils
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

            log.Info("test data received");
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

            log.Info("browser config received");
        }
    }
}
