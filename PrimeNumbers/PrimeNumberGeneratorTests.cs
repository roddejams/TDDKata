using System.Linq;
using NUnit.Framework;

namespace PrimeNumbers
{
    class PrimeNumberGeneratorTests
    {
        [Test]
        public void FirstPrimeNumberIsTwo()
        {
            var primeNumberGenerator = new PrimeNumberGenerator();
            var listOfPrimes = primeNumberGenerator.GetPrimes().ToList();

            Assert.That(listOfPrimes[0], Is.EqualTo(2));
        }
    }
}
