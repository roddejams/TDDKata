using System.Collections.Generic;
using System.Linq;

namespace PlayingCards
{
    public class PlayingCardSorter
    {
        public IEnumerable<PlayingCard> Sort(IEnumerable<PlayingCard> playingCards)
        {
            if (playingCards.Any())
            {
                var firstCard = playingCards.FirstOrDefault();
                var lastCard = playingCards.LastOrDefault();

                if (lastCard.Rank < firstCard.Rank)
                {
                    return new List<PlayingCard> {lastCard, firstCard};
                }
            }

            return playingCards;
        }
    }
}