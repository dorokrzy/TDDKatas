namespace RomanNumeralsJames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    namespace TDDTest.Common
    {
        public class RomanNumerals
        {
            public const string AllowableCharacters = "MDCLXVI";
            public static string Zero = "N";
            protected static Dictionary<char, int> NumeralValues = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000},
            };

            protected static Dictionary<string, int> NumeralConversions = new Dictionary<string, int>
            {
                {"I", 1},
                {"IV", 4},
                {"V", 5},
                {"IX", 9},
                {"X", 10},
                {"XL", 40},
                {"L", 50},
                {"LC", 90},
                {"C", 100},
                {"CD", 400},
                {"D", 500},
                {"CM", 900},
                {"M", 1000},
            };

            public static int ToInt(string input)
            {
                if (string.IsNullOrWhiteSpace(input) || input == Zero)
                {
                    return 0;
                }

                if (input.Except(AllowableCharacters).Any())
                {
                    throw new ArgumentException("The input string contains invalid characters", "input");
                }

                var chars = input.ToList();

                var total = 0;

                while (chars.Any())
                {
                    var v1 = GetValue(chars.First());
                    var c2 = chars.Skip(1).FirstOrDefault();

                    if (c2 == default(char))
                    {
                        total += v1;
                        break;
                    }

                    var v2 = GetValue(c2);
                    total += (v1 < v2) ? -v1 : v1;

                    chars.RemoveAt(0);
                }

                return total;
            }

            private static int GetValue(char ch)
            {
                return NumeralValues[ch];
            }

            public static string Convert(int value)
            {
                if (value < 0 || value > 3999)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (value == 0)
                {
                    return Zero;
                }

                var b = new StringBuilder();

                var values = NumeralConversions.OrderByDescending(x => x.Value).ToList();

                while (values.Any())
                {
                    var current = values.First();
                    while (value >= current.Value)
                    {
                        b.Append(current.Key);
                        value -= current.Value;
                    }
                    values.Remove(current);
                }

                return b.ToString();
            }
        }
    }

}
