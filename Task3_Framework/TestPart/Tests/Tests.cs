using NUnit.Framework;
using Task3_Framework.TestPart.Tests;


namespace Task3_Framework
{
    public class Tests:BaseTest
    {
        //[Test]
        public void TestCase1_AlertForms()
        {
            log.Info("Test case \"AlertForms\" started.");
            TestCase1Alerts alerts = new TestCase1Alerts();
            alerts.CheckAlertForms();
            log.Info("Test case \"AlertForms\" completed.");
        }

        //[Test]
        public void TestCase2_Iframe()
        {
            log.Info("Test case \"IFrame\" started.");
            TestCase2IFrame frames = new TestCase2IFrame();
            frames.CheckIframes();
            log.Info("Test case \"IFrame\" completed.");
        }

        //[Test]
        //[TestCase("User1")]
        //[TestCase("User2")]
        public void TestCase3_Tables(string configKey)
        {
            log.Info("Test case \"Tables\" started.");
            TestCase3Tables tables = new TestCase3Tables();
            tables.CheckTables(configKey);
            log.Info("Test case \"Tables\" completed.");
        }
    }
}