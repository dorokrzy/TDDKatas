using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TDDKatas.TheFizzBuzz
{
    /*
     * - Write a program that prints the numbers from 1 to 100. But for multiples of three print "Fizz"
  instead of the number and for the multiples of five print "Buzz". For numbers which are multiples of both
  three and five print "FizzBuzz".
    */

    class FizzBuzz
    {
        public string Print(int number)
        {
            if (number <= 0 || number > 100)
                throw new ArgumentException("message");

            if (IsFizz(number) && IsBuzz(number))
                return "FizzBuzz";

            if (IsFizz(number))
                return "Fizz";

            if (IsBuzz(number))
                return "Buzz";

            return number.ToString();
        }

        private bool IsFizz(int number){
            return number % 3 == 0;
        }

        private bool IsBuzz(int number)
        {
            return number % 5 == 0;
        }
    }

    [TestFixture]
    public class FizzBuzzTests
    {
        FizzBuzz fizzbuzz = new FizzBuzz();

        [Test]
        public void WhenNumberIsNotMultiplesOfThreeOrFive_ReturnNumber()
        {
            string result = fizzbuzz.Print(1);

            Assert.That(result, Is.EqualTo("1"));
        }

        [Test]
        public void WhenNumberIsMultiplesOfThree_ReturnFizz()
        {
            string result = fizzbuzz.Print(3);

            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void WhenNumberIsMultiplesOfFive_ReturnBuzz()
        {
            string result = fizzbuzz.Print(5);

            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void WhenNumberIsMultiplesOfFiveAndThree_ReturnFizzBuzz()
        {
            string result = fizzbuzz.Print(15);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(101)]
        public void WhenNumberIsOutOfRange_Throws(int number)
        {
            Assert.Throws<ArgumentException>(() => fizzbuzz.Print(number)); ;
        }
    }
}
