using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework.Constraints;

namespace RockPaperScissors
{
    internal class RockPaperScissorsGame
    {
        private readonly Player _player1;
        private readonly Player _player2;
        public readonly List<Move> Player1Moves = new List<Move>();
        public readonly List<Move> Player2Moves = new List<Move>();

        public RockPaperScissorsGame(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
            if (player1 == null) throw new ArgumentNullException(nameof(player1));
            if (player2 == null) throw new ArgumentNullException(nameof(player2));

            player1.Moved += (sender, args) =>
            {
                if (Player1Moves.Count <= Player2Moves.Count)
                {
                    Player1Moves.Add(args.Move);
                }
            };

            player2.Moved += (sender, args) => 
            {
                if (Player2Moves.Count <= Player1Moves.Count)
                {
                    Player2Moves.Add(args.Move);
                }
            };
        }

        public Tuple<KeyValuePair<string, int>, KeyValuePair<string, int>> GetScore()
        {
            var p1Score = 0;
            var p2Score = 0;
            var minMoves = Math.Min(Player1Moves.Count, Player2Moves.Count);
            for (int i = 0; i < minMoves; i++)
            {
                var p1 = Player1Moves[i];
                var p2 = Player2Moves[i];

                if (p1 == Move.Paper)
                {
                    if (p2 == Move.Rock)
                    {
                        p1Score++;
                    }
                }
            }

            return Tuple.Create(
                new KeyValuePair<string, int>(_player1.Name, p1Score),
                new KeyValuePair<string, int>(_player2.Name, p2Score)
            );
        }
    }
}