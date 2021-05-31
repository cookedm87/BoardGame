namespace BoardGame.Library.Abstract
{
    public interface IPlayGame
    {
        int MaximumMoves { get; }
        public IPlayer[] Players { get; set; }
        public IPlayer CurrentPlayer { get; set; }
        public IBoard Board { get; set; }

        public void Start();
    }
}
