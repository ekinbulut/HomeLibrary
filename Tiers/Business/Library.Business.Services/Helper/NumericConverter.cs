using System.Collections.Generic;

namespace Library.Business.Services.Helper
{
    public static class NumericConverter
    {
        private static readonly Dictionary<char, int> RomanMap;

        static NumericConverter()
        {
            RomanMap = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };
        }

        public static int? RomanToInteger(this string roman)
        {
            int? number = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
                {
                    number -= RomanMap[roman[i]];
                }
                else
                {
                    number += RomanMap[roman[i]];
                }
            }
            return number;
        }
    }
}
