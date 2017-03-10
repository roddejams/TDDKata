using System.Collections.Generic;
using NUnit.Framework;

namespace PrimeNumbers.ShoppingCart
{
    class ShoppingCartTests
    {
        [Test]
        public void EmptyCartShouldCostNothing()
        {
            var shoppingCart = new ShoppingCart(new List<ShoppingItem>());
            Assert.That(shoppingCart.CalculatePrice(), Is.EqualTo(0));
        }

        [Test]
        public void SingleItemShouldCostValue()
        {
            var shoppingItem = new ShoppingItem(10,1);
            var shoppingCart = new ShoppingCart(new List<ShoppingItem> { shoppingItem });

            Assert.That(shoppingCart.CalculatePrice(), Is.EqualTo(10));
        }

        [Test]
        public void MultipleOfSameItemShouldCostMore()
        {
            var shoppingItem = new ShoppingItem(10, 3);
            var shoppingCart = new ShoppingCart(new List<ShoppingItem> { shoppingItem });

            Assert.That(shoppingCart.CalculatePrice(), Is.EqualTo(30));
        }
    }
}
