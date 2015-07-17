using NUnit.Framework;

namespace TheOddEvenKataKata
{
    [TestFixture]
    public class TheOddEvenKata
    {
        Printer printer = new Printer();
        [Test]
        public void PrintsEvenForEvenNumbers()
        {
            string result = printer.Print(2);
            Assert.That(result, Is.EqualTo("Even"));
        }

        [Test]
        public void PrintsOddForOddNumbers()
        {
            string result = printer.Print(25);
            Assert.That(result, Is.EqualTo("Odd"));
        }


        [Test]
        public void PrintsPrimeForPrimeNumbers()
        {
            string result = printer.Print(13);
            Assert.That(result, Is.EqualTo("Prime"));
        }
    }

    public class Printer
    {
        public string Print(int number)
        {
            if (number % 2 == 0)
                return "Even";

            for (int i = 3; i < number; i=i+2)
            {
                if (number % i == 0)
                    return "Odd";
            }

            return "Prime";
        }
    }
}
