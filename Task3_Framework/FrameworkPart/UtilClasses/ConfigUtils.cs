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
        public static Dictionary<string, string> UserInfo = new Dictionary<string, string>();

        public static void GetTestData()
        {
            if (TestData.Count == 0)
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

        public static void ClearData()
        {
            DriverUtils.BrowserConfig.Clear();
            TestData.Clear();
            log.Info("test data and config data cleared");
        }


        public static void GetUserInfo(string key)
        {
            string allUserInfo = TestData[key];
            string[] separatedData = allUserInfo.Split("\t");

            List<string> userInfoFields = new List<string>()
                { "UserNumber", "FirstName", "LastName", "Email", "Age", "Salary", "Department" };

            UserInfo.Clear();

            for (int i = 0; i < separatedData.Length; i++)
            {
                UserInfo.Add(userInfoFields[i], separatedData[i]);
            }

            log.Info("user info received");
        }
    }
}
