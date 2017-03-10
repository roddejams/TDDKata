using System.Collections.Generic;
using System.Linq;

namespace PrimeNumbers.Primes
{
    public class PrimeNumberGenerator
    {
        public IEnumerable<int> GetPrimes()
        {
            var list = new List<int>();

            for (int i = 2; i < 1000; i++)
            {
                var remainders = list.Select(x => i%x);
                if (!remainders.Contains(0))
                {
                    list.Add(i);
                }
            }

            return list;
        }
    }
}
