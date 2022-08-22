using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace Task3_Framework.TestPart.Tests
{
    class TestCase3Tables
    {
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void CheckTables(string configKey)
        {
            ConfigUtils.GetUserInfo(configKey);

            UserModel userModelFromTestData = new UserModel();

            userModelFromTestData.SetModelFieldsFromTestData();
        }
    }
}
