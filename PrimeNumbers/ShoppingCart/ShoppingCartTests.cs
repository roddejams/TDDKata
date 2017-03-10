using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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

        [Test]
        public void ShouldHandleMultipleItems()
        {
            var shoppingItem1 = new ShoppingItem(10, 3);
            var shoppingItem2 = new ShoppingItem(5.5, 1);
            var shoppingItem3 = new ShoppingItem(2, 10);
            var shoppingCart = new ShoppingCart(new List<ShoppingItem> { shoppingItem1, shoppingItem2, shoppingItem3 });

            Assert.That(shoppingCart.CalculatePrice(), Is.EqualTo(55.5));
        }

        [Test]
        public void FivePercentDiscountShouldApplyOver100()
        {
            var item = new ShoppingItem(101, 1);
            var cart = new ShoppingCart(new List<ShoppingItem> { item });

            Assert.That(cart.CalculatePrice(), Is.EqualTo(101 * 0.95));
        }

        [Test]
        public void TenPercentDiscountShouldApplyOver200()
        {
            var item = new ShoppingItem(250, 1);
            var cart = new ShoppingCart(new List<ShoppingItem> { item });
            
            Assert.That(cart.CalculatePrice(), Is.EqualTo(225));
        }

        [Test]
        public void ShouldNotAllowNegativeQuantity()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ShoppingItem(10, -1));
        }

        [Test]
        public void ShouldNotAllowNegativePrice()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ShoppingItem(-2, 1));
        }
    }
}
