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
            return _contents.Sum(shoppingItem => shoppingItem.Price);
        }
    }

    class ShoppingItem
    {
        public double Price { get; set; }
        public int Quantity { get; set; }

        public ShoppingItem(double price, int quantity)
        {
            Price = price;
            Quantity = quantity;
        }
    }
}
