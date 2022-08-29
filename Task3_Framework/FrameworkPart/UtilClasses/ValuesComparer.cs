using System;
using log4net;

namespace Task3_Framework.FrameworkPart.UtilClasses
{
    class ValuesComparer
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static bool CompareDecimalsWithPrecission(decimal x1, decimal x2, decimal precissionPercent)
        {
            decimal difference = Math.Abs((x1 - x2) / ((x1 + x2) / 2)) * 100;

            log.Info(string.Format("Difference = {0}%", difference));

            return difference <= precissionPercent;
        }
    }
}
