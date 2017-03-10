using System.Collections.Generic;
using System.Linq;

namespace PrimeNumbers.ShoppingCart
{
    class ShoppingCart
    {
        private readonly IEnumerable<ShoppingItem> _contents;

        public ShoppingCart(IEnumerable<ShoppingItem> contents)
        {
            _contents = contents;
        }

        public double CalculatePrice()
        {
            var sum = _contents.Sum(shoppingItem => shoppingItem.Price);

            if (sum > 100)
            {
                return sum*0.95;
            }

            return sum;
        }
    }

    class ShoppingItem
    {
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        public double Price => UnitPrice*Quantity;

        public ShoppingItem(double unitPrice, int quantity)
        {
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
    }
}
