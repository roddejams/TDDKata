using System.Collections.Generic;
using System.Linq;

namespace PlayingCards
{
    public class PlayingCardSorter
    {
        public IList<PlayingCard> Sort(IList<PlayingCard> playingCards)
        {
            if (playingCards.Count() >= 2)
            {
                var first = playingCards.First();
                var rest = playingCards.Skip(1).ToList();
                var sortedRest = Sort(rest);
                foreach (var card in sortedRest.ToList())
                {
                    if (card > first)
                    {
                        sortedRest.Insert(sortedRest.IndexOf(card), first);
                        return sortedRest;
                    }
                }
                sortedRest.Add(first);
                return sortedRest;
            }

            return playingCards;
        }
    }
}