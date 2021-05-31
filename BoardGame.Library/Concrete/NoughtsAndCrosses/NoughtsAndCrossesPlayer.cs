using BoardGame.Library.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Library.Concrete.NoughtsAndCrosses
{
    public class NoughtsAndCrossesPlayer : IPlayer
    {
        public string Name { get; set; }
        public bool Winner { get; set; }
        public IBoard BoardGame { get; set; }

        public NoughtsAndCrossesPlayer(string name)
        {
            Name = name;
            Winner = false;
            BoardGame = new NoughtsAndCrossesBoard();
        }

        public IMove PlayTurn()
        {
            int x, y;
            Random random = new Random();
            IMove move = new NoughtsAndCrossesMove();

            x = random.Next(BoardGame.Size);
            y = random.Next(BoardGame.Size);
            move.XPosition = x;
            move.YPosition = y;
            move.Player = this;
            return move;
        }
    }
}
