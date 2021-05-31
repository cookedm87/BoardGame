namespace BoardGame.Library.Abstract
{
    public interface IPlayer
    {
        public string Name { get; set; }
        public bool Winner { get; set; }

        public IMove PlayTurn();
    }
}
