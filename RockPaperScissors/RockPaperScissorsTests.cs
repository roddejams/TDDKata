using System;
using NUnit.Framework;

namespace RockPaperScissors
{
    class RockPaperScissorsTests
    {
        [Test]
        public void GameShouldHaveTwoPlayers()
        {
            var player1 = new Player("");
            var player2 = new Player("");

            Assert.DoesNotThrow(() => new RockPaperScissorsGame(player1, player2));
        }

        [Test]
        public void GameShouldNotConstructWithoutTwoPlayers()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new RockPaperScissorsGame(null, null));

            Assert.That(exception.ParamName, Is.EqualTo("player1"));
        }

        [Test]
        public void GameShouldNotConstructWithOnlyOnePlayer()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new RockPaperScissorsGame(new Player(""), null));

            Assert.That(exception.ParamName, Is.EqualTo("player2"));
        }

        [TestCase(Move.Paper, Move.Rock, 1, 0)]
        [TestCase(Move.Paper, Move.Paper, 1, 1)]
        [TestCase(Move.Paper, Move.Scissors, 0, 1)]
        [TestCase(Move.Rock, Move.Rock, 1, 1)]
        [TestCase(Move.Rock, Move.Paper, 0, 1)]
        [TestCase(Move.Rock, Move.Scissors, 1, 0)]
        [TestCase(Move.Scissors, Move.Rock, 0, 1)]
        [TestCase(Move.Scissors, Move.Paper, 1, 0)]
        [TestCase(Move.Scissors, Move.Scissors, 1, 1)]
        public void PaperShouldWinAgainstRock(Move playerOneMove, Move playerTwoMove, int playerOneScore, int playerTwoScore)
        {
            var player1 = new Player("One");
            var player2 = new Player("Two");

            var game = new RockPaperScissorsGame(player1, player2);

            player1.SelectMove(playerOneMove);
            player2.SelectMove(playerTwoMove);

            var score = game.GetScore();
            Assert.That(score.Item1.Value, Is.EqualTo(playerOneScore));
            Assert.That(score.Item2.Value, Is.EqualTo(playerTwoScore));
        }

        [Test]
        public void PlayerCanWinGame()
        {
            var player1 = new Player("One");
            var player2 = new Player("Two");

            var game = new RockPaperScissorsGame(player1, player2);

            //Round 1
            player1.SelectMove(Move.Rock);
            player2.SelectMove(Move.Scissors);

            //Round 2
            player1.SelectMove(Move.Rock);
            player2.SelectMove(Move.Scissors);

            //Round 3
            player1.SelectMove(Move.Rock);
            player2.SelectMove(Move.Scissors);

            var winner = game.Winner();

            Assert.That(winner, Is.EqualTo("One"));
        }
    }
}
