using System;
using System.Collections.Generic;

namespace Task3_Framework.FrameworkPart.UtilClasses
{
    class RandomIntGenerator
    {
        public static int GenerateRandomInt(List<int> values)
        {
            Random random = new Random();
            return random.Next(values[0], values[1]);
        }
    }
}
