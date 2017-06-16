namespace PlayingCards
{
    public class PlayingCard
    {
        public PlayingCard(int rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public int Rank { get; }
        public Suit Suit { get; }

        public override bool Equals(object obj)
        {
            var otherCard = obj as PlayingCard;
            return Rank == otherCard?.Rank && Suit == otherCard.Suit;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator <(PlayingCard left, PlayingCard right)
        {
            if (left.Rank < right.Rank) return true;
            if (left.Rank > right.Rank) return false;
            return left.Suit < right.Suit;
        }

        public static bool operator >(PlayingCard left, PlayingCard right)
        {
            return right < left;
        }

    }

    public enum Suit
    {
        Club,
        Diamond,
        Heart,
        Spade
    }
}