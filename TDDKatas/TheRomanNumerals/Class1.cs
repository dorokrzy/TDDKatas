using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    [TestFixture]
    public class RomanNumeralsTests
    {
        [Test]
        public void BaseNumbersAreConvertedToRoman()
        {
            var convertor = new RomanNumeralsConverter();

            Assert.AreEqual(convertor.ToRoman(1), "I");
            Assert.AreEqual(convertor.ToRoman(4), "IV");
            Assert.AreEqual(convertor.ToRoman(5), "V");
            Assert.AreEqual(convertor.ToRoman(9), "IX");
            Assert.AreEqual(convertor.ToRoman(10), "X");
            Assert.AreEqual(convertor.ToRoman(40), "XL");
            Assert.AreEqual(convertor.ToRoman(50), "L");
            Assert.AreEqual(convertor.ToRoman(90), "XC");
            Assert.AreEqual(convertor.ToRoman(100), "C");
            Assert.AreEqual(convertor.ToRoman(400), "CD");
            Assert.AreEqual(convertor.ToRoman(500), "D");
            Assert.AreEqual(convertor.ToRoman(900), "CM");
            Assert.AreEqual(convertor.ToRoman(1000), "M");
        }

        [Test]
        public void NumberSmallerOrEqualZeroOrGreaterThan1000AreNotConverted()
        {
            var convertor = new RomanNumeralsConverter();

            Assert.AreEqual(convertor.ToRoman(-1), "NaN");
            Assert.AreEqual(convertor.ToRoman(0), "NaN");
            Assert.AreEqual(convertor.ToRoman(1001), "NaN");
        }

        [Test]
        public void OtherNumbersAreConvertedToRoman()
        {
            var convertor = new RomanNumeralsConverter();

            Assert.AreEqual(convertor.ToRoman(2), "II");
            Assert.AreEqual(convertor.ToRoman(3), "III");
            Assert.AreEqual(convertor.ToRoman(37), "XXXVII");
            Assert.AreEqual(convertor.ToRoman(47), "XLVII");
            Assert.AreEqual(convertor.ToRoman(300), "CCC");
            Assert.AreEqual(convertor.ToRoman(501), "DI");
            Assert.AreEqual(convertor.ToRoman(990), "CMXC");
        }

        [Test]
        public void ConvertRomanToArabic()
        {
            var convertor = new RomanNumeralsConverter();

            Assert.AreEqual(1, convertor.ToArabic("I"));
            Assert.AreEqual(1000, convertor.ToArabic("M"));
            Assert.AreEqual(50, convertor.ToArabic("L"));
            Assert.AreEqual(9, convertor.ToArabic("IX"));
            Assert.AreEqual(990, convertor.ToArabic("CMXC"));
            Assert.AreEqual(501, convertor.ToArabic("DI"));
            Assert.AreEqual(37, convertor.ToArabic("XXXVII"));
            Assert.AreEqual(47, convertor.ToArabic("XLVII"));
        }
    }
}
