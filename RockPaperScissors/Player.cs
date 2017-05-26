using System;

namespace RockPaperScissors
{
    internal class Player
    {
        public delegate void MovedEventHandler(object sender, MoveEventArgs e);

        public event MovedEventHandler Moved;
        public string Name { get; }


        public Player(string name)
        {
            Name = name;
        }

        public void SelectMove(Move move)
        {
            Moved?.Invoke(this, new MoveEventArgs(move));
        }
    }

    internal class MoveEventArgs
    {
        public Move Move { get; }

        public MoveEventArgs(Move move)
        {
            Move = move;
        }
    }
}