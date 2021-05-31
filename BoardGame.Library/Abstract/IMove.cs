namespace BoardGame.Library.Abstract
{
    public interface IMove
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public IPlayer Player { get; set; }
    }
}
