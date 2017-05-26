namespace RockPaperScissors
{
    internal class GameRound
    {
        protected bool Equals(GameRound other)
        {
            return Move1 == other.Move1 && Move2 == other.Move2;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GameRound) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Move1 * 397) ^ (int) Move2;
            }
        }

        public GameRound(Move move1, Move move2)
        {
            Move1 = move1;
            Move2 = move2;
        }

        public Move Move1 { get; set; }
        public Move Move2 { get; set; }
    }
}