using System;
using System.Collections.Generic;
using log4net;

namespace Task3_Framework.FrameworkPart.UtilClasses
{
    public static class StringUtil
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string StringGenerator(int lettersCount)
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghigklmnopqrstuvwxyz".ToCharArray();

            Random rand = new Random();

            string word = "";

            for (int j = 1; j <= lettersCount; j++)
            {
                int letter = rand.Next(0, letters.Length - 1);

                word += letters[letter];
            }
            log.Info(string.Format("generated random text = {0}", word));
            return word;
        }

        public static List<string> GetSeparateddStrings(string text, string splitter)
        {
            string[] separatedData = text.Split(splitter);

            List<string> userInfoFields = new List<string>();

            for (int i = 0; i < separatedData.Length; i++)
            {
                userInfoFields.Add(separatedData[i]);
            }

            log.Info("strings separated");
            return userInfoFields;
        }
    }
}
