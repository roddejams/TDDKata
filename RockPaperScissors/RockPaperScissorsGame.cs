using System;
using System.Collections.Generic;

namespace RockPaperScissors
{

    internal class RockPaperScissorsGame
    {
        private readonly Player _player1;
        private readonly Player _player2;
        public readonly List<Move> Player1Moves = new List<Move>();
        public readonly List<Move> Player2Moves = new List<Move>();
        public readonly IDictionary<GameRound, int> ScoreMapping = new Dictionary<GameRound, int>
        {
            { new GameRound(Move.Paper, Move.Rock), 1 },
            { new GameRound(Move.Paper, Move.Scissors), 2 },

            { new GameRound(Move.Rock, Move.Paper), 2 },
            { new GameRound(Move.Rock, Move.Scissors), 1 },

            { new GameRound(Move.Scissors, Move.Paper), 1 },
            { new GameRound(Move.Scissors, Move.Rock), 2 }
        };

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

        public (KeyValuePair<string, int> player1, KeyValuePair<string, int> player2) GetScore()
        {
            var p1Score = 0;
            var p2Score = 0;
            var numRounds = GetPlayedRoundCount();
            for (int i = 0; i < numRounds; i++)
            {
                var p1 = Player1Moves[i];
                var p2 = Player2Moves[i];

                if (p1 == p2)
                {
                    p1Score++;
                    p2Score++;
                }
                else
                {
                    var score = ScoreMapping[new GameRound(p1, p2)];

                    if (score == 1)
                    {
                        p1Score++;
                    }
                    else
                    {
                        p2Score++;
                    }
                }
            }

            return (
                new KeyValuePair<string, int>(_player1.Name, p1Score),
                new KeyValuePair<string, int>(_player2.Name, p2Score)
            );
        }

        private int GetPlayedRoundCount()
        {
            var minMoves = Math.Min(Player1Moves.Count, Player2Moves.Count);
            return minMoves;
        }

        public string Winner()
        {
            var score = GetScore();

            var playerOneScore = score.player1.Value;
            var playerTwoScore = score.player2.Value;

            if (GetPlayedRoundCount() >= 3)
            {
                if (playerOneScore > playerTwoScore)
                {
                    return _player1.Name;
                }

                if (playerTwoScore > playerOneScore)
                {
                    return _player2.Name;
                }
            }

            return null;
        }
    }
}