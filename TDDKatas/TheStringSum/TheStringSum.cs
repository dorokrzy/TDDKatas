using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TDDKatas.TheStringSum
{
    /*
     Write a simple String Sum utility with a function string Sum(string num1, string num2), 
     which can accept only natural numbers and will return their sum. Replace entered number with 0
     (zero) if entered number is not a natural number.
     
     Stat with a simplest test case with an empty string
     Create a simple method string Sum(string num1, string num2)
     Write a test to pass small numbers and refactor, if test passed try to write more code and refactor*/
    
    class StringSum
    {
        public string Sum(string num1, string num2) {
            
            return (GetNaturalNumber(num1) +GetNaturalNumber(num2)).ToString();
        }

        private int GetNaturalNumber(string num)
        {
            int result;
            if (Int32.TryParse(num, out result))
            {
                if (result > 0)
                    return result;
            }

            return 0;
        }
    }

    [TestFixture]
    class StringSumTests
    {
        StringSum stringSum = new StringSum();

        [SetUp]
        public void SetUp(){

        }

        [Test]
        public void EmptyStringReturnZero()
        {
            var result = stringSum.Sum(string.Empty, string.Empty);
            Assert.That(result, Is.EqualTo("0"));
        }

        [Test]
        public void WhenArgumentsAreNaturalNumbers_TheSumIsReturned()
        {
            var result = stringSum.Sum("1", "1");
            Assert.That(result, Is.EqualTo("2"));
        }

        [Test]
        public void WhenOneOfArgumentsIsEmptyStringAndSecondIsNaturalNumber_TheSumIsNaturalNumber()
        {
            var result = stringSum.Sum(string.Empty, "2");
            Assert.That(result, Is.EqualTo("2"));
        }

        [Test]
        public void WhenOneOfArgumentsIsNotNaturalNumberAndSecondIsNaturalNumber_TheSumIsNaturalNumber()
        {
            var result = stringSum.Sum("-2", "2");
            Assert.That(result, Is.EqualTo("2"));
        }
    }
}
