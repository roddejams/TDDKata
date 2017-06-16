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
            var singleItem = new List<PlayingCard> {new PlayingCard(1)};

            var sorter = new PlayingCardSorter();
            var sorted = sorter.Sort(singleItem);

            Assert.That(sorted.Count(), Is.EqualTo(1));
        }

        [Test]
        public void CardSorter_SortsListOfSizeTwoCorrectly()
        {
            var firstCard = new PlayingCard(2);
            var secondCard = new PlayingCard(1);
            var twoItems = new List<PlayingCard> { firstCard, secondCard };

            var sorter = new PlayingCardSorter();
            var sorted = sorter.Sort(twoItems);

            Assert.That(sorted.Count(), Is.EqualTo(2));
            Assert.That(sorted.First(), Is.EqualTo(secondCard));
            Assert.That(sorted.Last(), Is.EqualTo(firstCard));
        }
    }
}
