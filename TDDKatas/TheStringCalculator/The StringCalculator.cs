using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace TheStringCalculatorKata
{
    [TestFixture]
    public class The_StringCalculator
    {
        private StringCalculator stringCalculator;

        [SetUp]
        public void SetUp()
        {
            stringCalculator = new StringCalculator();
        }


        [Test]
        public void EmptyStringReturn0()
        {
            var actual = stringCalculator.Add("");
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void SingleNumberReturnValue()
        {
            var actual = stringCalculator.Add("1");
            Assert.That(actual, Is.EqualTo(1));
        }

        [Test]
        public void TwoNumberReturnSum()
        {
            var actual = stringCalculator.Add("1,2");
            Assert.That(actual, Is.EqualTo(3));
        }

        [Test]
        public void ThreeNumberReturnSum()
        {
            var actual = stringCalculator.Add("1,2,3");
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void CalculatorHandlesWhiteSpaceAsSeparator()
        {
            var actual = stringCalculator.Add("1\n2,3");
            Assert.That(actual, Is.EqualTo(6));
        }


        [Test]
        public void CalculatorSupportsCustomSeparator()
        {
            var actual = stringCalculator.Add("//;\n1;2");
            Assert.That(actual, Is.EqualTo(3));
        }

        [Test]
        public void  NegativeNumbersAreReturnedInExceptiopnMessage()
        {
            var exception = Assert.Throws<Exception>(() => stringCalculator.Add("//;\n1;-2;-4"));
            Assert.That(exception.Message, Is.EqualTo("-2,-4"));
        }

        [Test]
        public void NumbersGreaterThan1000AreIgnored()
        {
            var actual = stringCalculator.Add("//;\n1;2;1001");
            Assert.That(actual, Is.EqualTo(3));
        }

        [Test]
        public void SeperatorCanBeOfAnyFormat()
        {
            var actual = stringCalculator.Add("//***\n1***2***4");
            Assert.That(actual, Is.EqualTo(7));
        }

        [Test]
        public void SeperatorCanBeOfAnyDefferent()
        {
            var actual = stringCalculator.Add("//[*][%]\n1*2%3");
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void SeperatorCanBeOfAnyDefferentAndDifferentLength()
        {
            var actual = stringCalculator.Add("//[*][%%%]\n1*2%%%3");
            Assert.That(actual, Is.EqualTo(6));
        }
    }

    public class StringCalculator
    {
        private string[] mainSeparators = new[] { "," };
        char whiteSpace = '\n';

        public int Add(string input)
        {
            if (input == string.Empty)
                return 0;
            
            var lines = input.Split(whiteSpace);

            if (lines.Count() > 1)
            {
                //Replace separator
                if (lines[0].Contains("//"))
                {
                    mainSeparators = ParseSeparators(lines[0].Replace("//", string.Empty));
                    input = input.Remove(0, lines[0].Length);
                }
            }


            var values = new List<string>();

            foreach (var number in Split(input, mainSeparators))
            {
                values.AddRange(number.Split(whiteSpace));
            }

            var negatives = new List<string>();
            var sum = 0;

            foreach (var value in values)
            {
                var converted = ConvertToInt(value);

                if (converted > 1000)
                    continue;
                
                if (converted < 0)
                {
                    negatives.Add(value);
                }
                sum = sum + converted;
            }
            
            if (negatives.Count() > 0)
                throw new Exception(string.Join(",", negatives));

            return sum;
        }

        private string[] ParseSeparators(string replace)
        {
            if (replace == string.Empty)
                return  new [] {","};

            if (replace.Length > 2)
                return replace.Substring(1, replace.Length - 2).Split(new[] {"]["}, StringSplitOptions.None);

            return new[] { replace };
        }

        private string[] Split(string input, string[] separators)
        {
            return input.Split(separators, StringSplitOptions.None);
        }

        private int ConvertToInt(string input)
        {
            if (input == string.Empty)
                return 0;

            return Convert.ToInt32(input);
        }
    }
}
