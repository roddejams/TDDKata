using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace PrimeNumbers
{
    class PrimeNumberGeneratorTests
    {
        private List<int> _listOfPrimes;

        [SetUp]
        public void SetUp()
        {
            var primeNumberGenerator = new PrimeNumberGenerator();
            _listOfPrimes = primeNumberGenerator.GetPrimes().ToList();
        }

        [TestCase(0, 2)]
        [TestCase(1, 3)]
        [TestCase(2, 5)]
        public void NthPrimeNumberIsCorrect(int index, int primeValue)
        {
            Assert.That(_listOfPrimes[index], Is.EqualTo(primeValue));
        }
    }
}
