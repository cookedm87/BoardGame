using BoardGame.Library.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace BoardGame.Library.Concrete.NoughtsAndCrosses
{
    public class NoughtsAndCrossesBoard : IBoard
    {
        public IPlayer[,] BoardGameTable { get; set; }
        public List<IMove> Movements { get; set; }

        public int Size => 3;

        public NoughtsAndCrossesBoard()
        {
            BoardGameTable = new NoughtsAndCrossesPlayer[Size, Size];
            Movements = new List<IMove>();
        }

        public bool AnyWinner()
        {
            if(Movements.Count() < 5)
            {
                return false;
            }

            // Rows
            if (SpaceTaken(BoardGameTable[0, 0]) == SpaceTaken(BoardGameTable[0, 1]) && SpaceTaken(BoardGameTable[0, 1]) == SpaceTaken(BoardGameTable[0, 2]))
            {
                return (BoardGameTable[0, 0] == null ? false : BoardGameTable[0, 0].Winner = true);
            }
            if (SpaceTaken(BoardGameTable[1, 0]) == SpaceTaken(BoardGameTable[1, 1]) && SpaceTaken(BoardGameTable[1, 1]) == SpaceTaken(BoardGameTable[1, 2]))
            {
                return (BoardGameTable[1, 0] == null ? false : BoardGameTable[1, 0].Winner = true);
            }
            if (SpaceTaken(BoardGameTable[2, 0]) == SpaceTaken(BoardGameTable[2, 1]) && SpaceTaken(BoardGameTable[2, 1]) == SpaceTaken(BoardGameTable[2, 2]))
            {
                return (BoardGameTable[2, 0] == null ? false : BoardGameTable[2, 0].Winner = true);
            }

            //Columns
            if (SpaceTaken(BoardGameTable[0, 0]) == SpaceTaken(BoardGameTable[1, 0]) && SpaceTaken(BoardGameTable[1, 0]) == SpaceTaken(BoardGameTable[2, 0]))
            {
                return (BoardGameTable[0, 0] == null ? false : BoardGameTable[0, 0].Winner = true);
            }
            if (SpaceTaken(BoardGameTable[0, 1]) == SpaceTaken(BoardGameTable[1, 1]) && SpaceTaken(BoardGameTable[1, 1]) == SpaceTaken(BoardGameTable[2, 1]))
            {
                return (BoardGameTable[0, 1] == null ? false : BoardGameTable[0, 1].Winner = true);
            }
            if (SpaceTaken(BoardGameTable[0, 2]) == SpaceTaken(BoardGameTable[1, 2]) && SpaceTaken(BoardGameTable[1, 2]) == SpaceTaken(BoardGameTable[2, 2]))
            {
                return (BoardGameTable[0, 2] == null ? false : BoardGameTable[0, 2].Winner = true);
            }

            //Diagonals
            if (SpaceTaken(BoardGameTable[0, 0]) == SpaceTaken(BoardGameTable[1, 1]) && SpaceTaken(BoardGameTable[1, 1]) == SpaceTaken(BoardGameTable[2, 2]))
            {
                return (BoardGameTable[0, 0] == null ? false : BoardGameTable[0, 0].Winner = true);
            }
            if (SpaceTaken(BoardGameTable[2, 0]) == SpaceTaken(BoardGameTable[1, 1]) && SpaceTaken(BoardGameTable[1, 1]) == SpaceTaken(BoardGameTable[0, 2]))
            {
                return (BoardGameTable[2, 0] == null ? false : BoardGameTable[2, 0].Winner = true);
            }

            return false;
        }

        public string SpaceTaken(IPlayer player)
        {
            if(player == null)
            {
                return "-";
            }
            else
            {
                return player.Name.ToString();
            }
        }

        public void RequestMovement(IPlayer player)
        {
            while (!MovementValid(player.PlayTurn(), player)) ;
        }

        public bool MovementValid(IMove move, IPlayer player)
        {
            if(Movements.Count() > 0)
            {
                if(Movements.ToList().Exists(m => (m.XPosition == move.XPosition) && (m.YPosition == move.YPosition)))
                {
                    return false;
                }
            }
            BoardGameTable[move.XPosition, move.YPosition] = player;
            Movements.Add(move);
            return true;
        }
    }
}
