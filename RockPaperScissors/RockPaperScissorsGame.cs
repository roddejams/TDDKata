using System;

namespace RockPaperScissors
{
    internal class RockPaperScissorsGame
    {
        public RockPaperScissorsGame(Player player1, Player player2)
        {
            if (player1 == null) throw new ArgumentNullException(nameof(player1));
            if (player2 == null) throw new ArgumentNullException(nameof(player2));
        }
    }
}