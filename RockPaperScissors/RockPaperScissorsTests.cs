using System;
using NUnit.Framework;

namespace RockPaperScissors
{
    class RockPaperScissorsTests
    {
        [Test]
        public void GameShouldHaveTwoPlayers()
        {
            var player1 = new Player();
            var player2 = new Player();

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
            var exception = Assert.Throws<ArgumentNullException>(() => new RockPaperScissorsGame(new Player(), null));

            Assert.That(exception.ParamName, Is.EqualTo("player2"));
        }
    }
}
