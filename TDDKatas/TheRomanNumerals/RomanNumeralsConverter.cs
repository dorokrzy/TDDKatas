using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumerals
{
    public class RomanNumeralsConverter
    {
        Dictionary<int, string> baseLetters = new Dictionary<int, string>()
        {
            { 1, "I" }, {4, "IV"}, {5, "V"} , {9, "IX"}, {10, "X"},
            {40, "XL"}, {50, "L" }, {90, "XC"}, { 100, "C" }, {400, "CD"},
            {500, "D"}, {900, "CM" }, {1000, "M"}
        };

        public string ToRoman(int numberToConvert)
        {
            if (IsOutsideTheConvertorRange(numberToConvert))
                return "NaN";

            
            var result = new StringBuilder();
            int reminder = numberToConvert;

            foreach(var baseLetter in baseLetters.Keys.OrderByDescending(x => x)){

                while (reminder >= baseLetter)
                {
                    result.Append(baseLetters[baseLetter]);
                    reminder = reminder - baseLetter;
                }

                /*
                int remider = number % baseLetter;
                
                double quatient = Math.Floor(((double)number/baseLetter));

                if (quatient >= 1)
                {
                    for (int i = 0; i < quatient; i++)
                        
                }
                
                if (remider > 0)
                {
                    number = remider;
                }
                else break;*/
            }

            return result.ToString();
        }

        private bool IsOutsideTheConvertorRange(int p)
        {
            return p <= 0 || p > 1000;
        }

        public int ToArabic(string p)
        {
            if (p.Length == 1)
                return baseLetters.Where(x => x.Value == p).FirstOrDefault().Key;

            int i = 0;
            int sum = 0;

            while (i < p.Length - 1)
            {
                var current = baseLetters.Where(x => x.Value == p[i].ToString()).FirstOrDefault().Key;
                var next = baseLetters.Where(x => x.Value == p[i+1].ToString()).FirstOrDefault().Key;

                if (current >= next)
                    sum = sum + current;
                else
                    sum = sum - current;

                i++;
            }

            sum = sum + baseLetters.Where(x => x.Value == p[p.Length - 1].ToString()).FirstOrDefault().Key;

            return sum;
        }
    }
}
