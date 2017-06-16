using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace PlayingCards
{
    public class PlayingCardTests
    {
        [Test]
        public void CardSorter_SortsListOFSizeZeroCorrectly()
        {
            var empty = new List<PlayingCard>();

            var sorter = new PlayingCardSorter();
            var sorted = sorter.Sort(empty);

            Assert.IsEmpty(sorted);
        }

        [Test]
        public void CardSorter_SortsListOfSizeOneCorrectly()
        {
            var singleItem = new List<PlayingCard> {new PlayingCard(1, Suit.Heart)};

            var sorter = new PlayingCardSorter();
            var sorted = sorter.Sort(singleItem);

            Assert.That(sorted.Count(), Is.EqualTo(1));
        }

        [Test]
        public void CardSorter_SortsListOfSizeTwoCorrectly()
        {
            var firstCard = new PlayingCard(2, Suit.Heart);
            var secondCard = new PlayingCard(1, Suit.Heart);
            var twoItems = new List<PlayingCard> { firstCard, secondCard };

            var sorter = new PlayingCardSorter();
            var sorted = sorter.Sort(twoItems);

            Assert.That(sorted.Count(), Is.EqualTo(2));
            Assert.That(sorted.First(), Is.EqualTo(secondCard));
            Assert.That(sorted.Last(), Is.EqualTo(firstCard));
        }

        [Test]
        public void CardSorter_SortsListOfSizeTwoWithCardsEqualCorrectly()
        {
            var firstCard = new PlayingCard(1, Suit.Heart);
            var secondCard = new PlayingCard(1, Suit.Heart);
            var twoItems = new List<PlayingCard> { firstCard, secondCard };

            var sorter = new PlayingCardSorter();
            var sorted = sorter.Sort(twoItems);

            Assert.That(sorted.Count(), Is.EqualTo(2));
            Assert.That(sorted.First(), Is.EqualTo(firstCard));
            Assert.That(sorted.Last(), Is.EqualTo(secondCard));
        }

        [Test]
        public void CardSorter_SortsListOfSizeTwoWithDifferentSuits()
        {
            var first = new PlayingCard(1, Suit.Heart);
            var second = new PlayingCard(1, Suit.Diamond);
            var twoItems = new List<PlayingCard> { first, second };

            var sorter = new PlayingCardSorter();
            var sorted = sorter.Sort(twoItems);

            Assert.That(sorted.Count(), Is.EqualTo(2));
            Assert.That(sorted.First(), Is.EqualTo(second));
            Assert.That(sorted.Last(), Is.EqualTo(first));
        }

        [Test]
        public void CardSorter_SortsListOfSizeThree()
        {
            var first = new PlayingCard(2, Suit.Heart);
            var second = new PlayingCard(3, Suit.Heart);
            var third = new PlayingCard(4, Suit.Heart);

            var cards = new List<PlayingCard> {second, first, third};

            var sortedCards = new PlayingCardSorter().Sort(cards);

            Assert.That(sortedCards.First(), Is.EqualTo(first));
            Assert.That(sortedCards.Last(), Is.EqualTo(third));
        }

        [Test]
        public void CardSorter_SortsThreeItemsWithSuits()
        {
            var first = new PlayingCard(2, Suit.Heart);
            var second = new PlayingCard(3, Suit.Diamond);
            var third = new PlayingCard(3, Suit.Heart);

            var cards = new List<PlayingCard> { second, first, third };

            var sortedCards = new PlayingCardSorter().Sort(cards);

            Assert.That(sortedCards.First(), Is.EqualTo(first));
            Assert.That(sortedCards.Last(), Is.EqualTo(third));
        }

        [Test]
        public void CardSorter_SortsLongListWithSuits()
        {
            var cards = new List<PlayingCard>
            {
                new PlayingCard(1, Suit.Heart), new PlayingCard(4, Suit.Spade), new PlayingCard(9, Suit.Diamond), new PlayingCard(9, Suit.Club), new PlayingCard(2, Suit.Club),
                new PlayingCard(13, Suit.Diamond), new PlayingCard(2, Suit.Heart), new PlayingCard(5, Suit.Heart), new PlayingCard(8, Suit.Spade), new PlayingCard(12, Suit.Heart)
            };
            var expected = new List<PlayingCard>
            {
                new PlayingCard(1, Suit.Heart), new PlayingCard(2, Suit.Club), new PlayingCard(2, Suit.Heart), new PlayingCard(4, Suit.Spade), new PlayingCard(5, Suit.Heart),
                new PlayingCard(8, Suit.Spade), new PlayingCard(9, Suit.Club), new PlayingCard(9, Suit.Diamond), new PlayingCard(12, Suit.Heart), new PlayingCard(13, Suit.Diamond)
            };

            var sortedCards = new PlayingCardSorter().Sort(cards);

            CollectionAssert.AreEqual(sortedCards, expected);
        }
    }
}
