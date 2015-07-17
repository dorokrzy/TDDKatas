using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ThePrimeFactorsKata
{
    [TestFixture]
    public class ThePrimeFactors
    {
        PrimeFactorsGenerator generator = new PrimeFactorsGenerator();

        [Test]
        public void TestOne()
        {
            Assert.That(new List<int>{}, Is.EqualTo(generator.PrimeFactors(1)));
        }

        [Test]
        public void TestTwo()
        {
            Assert.That(new List<int> {2}, Is.EqualTo(generator.PrimeFactors(2)));
        }

        [Test]
        public void TestThree()
        {
            Assert.That(new List<int> { 3 }, Is.EqualTo(generator.PrimeFactors(3)));
        }

        [Test]
        public void TestFour()
        {
            Assert.That(new List<int> { 2, 2 }, Is.EqualTo(generator.PrimeFactors(4)));
        }

        [Test]
        public void TestSix()
        {
            Assert.That(new List<int> { 2, 3 }, Is.EqualTo(generator.PrimeFactors(6)));
        }

        [Test]
        public void TestEight()
        {
            Assert.That(new List<int> { 2, 2, 2 }, Is.EqualTo(generator.PrimeFactors(8)));
        }


        [Test]
        public void TestNine()
        {
            Assert.That(new List<int> { 3, 3 }, Is.EqualTo(generator.PrimeFactors(9)));
        }
    }

    internal class PrimeFactorsGenerator
    {
        public List<int> PrimeFactors(int i)
        {
            var result = new List<int> {};

            int candidate = 2;
            while(i > 1)
            {
                for (; i%candidate == 0;i /= candidate)
                {
                    result.Add(candidate);
                }
                candidate++;
            }

            if (i > 1)
                result.Add(i);

            return result;
        }
    }
}
