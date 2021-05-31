using System.Collections.Generic;

namespace BoardGame.Library.Abstract
{
    public interface IBoard
    {
        public int Size { get; }

        public IPlayer[,] BoardGameTable { get; set; }
        public List<IMove> Movements { get; set; }

        public bool AnyWinner();
        public bool MovementValid(IMove move, IPlayer player);
        public void RequestMovement(IPlayer player);
    }
}
