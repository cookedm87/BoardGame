using BoardGame.Library.Abstract;

namespace BoardGame.Library.Concrete.NoughtsAndCrosses
{
    public class NoughtsAndCrossesMove : IMove
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public IPlayer Player { get; set; }
    }
}
