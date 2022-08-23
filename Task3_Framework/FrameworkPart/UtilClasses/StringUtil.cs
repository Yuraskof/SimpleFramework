using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using log4net;
using OpenQA.Selenium;

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

        public static List<decimal> ParsePrices(string prices)
        {
            string text = Regex.Replace(prices, @"[,]+", "");

            List<decimal> gamePrices = new List<decimal>();

            for (Match match = Regex.Match(text, @"\d+"); match.Success; match = match.NextMatch())
            {
                decimal price = Decimal.Parse(match.Value, NumberStyles.Any) / 100;

                gamePrices.Add(price);
            }

            return gamePrices;
        }

        public static int ConvertToIntSearchResults(string text)
        {
            string clearText = Regex.Replace(text, @"[,]+", "");

            int convertedValue = int.Parse(Regex.Match(text, @"\d+").Value, NumberFormatInfo.InvariantInfo);

            return convertedValue;
        }

        public static List<string> GetTextFromFilterElements(IReadOnlyList<IWebElement> elements)
        {
            List<string> parcedText = new List<string>();

            for (int i = 0; i < elements.Count - 1; i++)
            {
                String textInElement = elements[i].Text;
                string textClear = textInElement.Replace("\"", "");

                parcedText.Add(textClear);
            }

            return parcedText;
        }
    }
}
