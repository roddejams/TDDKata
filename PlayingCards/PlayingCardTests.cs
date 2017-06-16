using System.Collections;
using System.Collections.Generic;
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
    }
}
