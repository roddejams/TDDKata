using NUnit.Framework;

namespace PrimeNumbers.ShoppingCart
{
    class ShoppingCartTests
    {
        [Test]
        public void EmptyCartShouldCostNothing()
        {
            var shoppingCart = new ShoppingCart();
            Assert.That(shoppingCart.CalculatePrice(), Is.EqualTo(0));
        }
    }
}
