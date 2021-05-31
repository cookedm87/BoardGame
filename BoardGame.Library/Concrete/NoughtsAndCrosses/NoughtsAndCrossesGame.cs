using BoardGame.Library.Abstract;
using System;
using System.Linq;

namespace BoardGame.Library.Concrete.NoughtsAndCrosses
{
    public class NoughtsAndCrossesGame
    {
        private readonly IBoard _board;
        private readonly ITextWriter _writer;
        public IPlayer CurrentPlayer { get; set; }
        public IPlayer[] Players { get; set; }
        public int MaximumMoves { get; private set; }

        public NoughtsAndCrossesGame(IBoard board, ITextWriter textWriter)
        {
            _writer = textWriter;
            _board = board;
            Players = new IPlayer[]
            {
                new NoughtsAndCrossesPlayer("O"),
                new NoughtsAndCrossesPlayer("X")
            };
            CurrentPlayer = Players[0];
            MaximumMoves = _board.Size * _board.Size;
        }

        public void Start()
        {
            int movements = 0;
            bool winner = false;
            while(!winner && movements < MaximumMoves)
            {
                _board.RequestMovement(CurrentPlayer);
                winner = _board.AnyWinner();
                ChangePlayer();
                movements++;
                PrintMove();
            }
            PrintResults();
        }

        private void ChangePlayer()
        {
            if(CurrentPlayer.Name == "O")
            {
                CurrentPlayer = Players.Where(p => p.Name == "X").FirstOrDefault();
            }
            else
            {
                CurrentPlayer = Players.Where(p => p.Name == "O").FirstOrDefault();
            }
        }

        private void PrintMove()
        {
            string toPrint = string.Empty;
            IMove move = new NoughtsAndCrossesMove();
            for(int xPosition = 0; xPosition < _board.Size; xPosition++)
            {
                for(int yPosition = 0; yPosition < _board.Size; yPosition++)
                {
                    if(_board.Movements.Where(m => m.XPosition == xPosition && m.YPosition == yPosition).Any())
                    {
                        move = _board.Movements.Where(m => m.XPosition == xPosition && m.YPosition == yPosition).First();
                        toPrint += move.Player.Name;
                    }                    
                    else
                    {
                        toPrint += "-";
                    }
                }
                toPrint += Environment.NewLine;
            }
            _writer.Write(toPrint);
        }

        private void PrintResults()
        {
            if (Players.Where(p => p.Winner).Any())
            {
                _writer.Write("Player " + Players.Where(p => p.Winner).First().Name + " won");           
            }
            else
            {
                _writer.Write("It's a Draw");
            }
            Console.ReadLine();
        }
    }
}
