using BoardGame.Library.Abstract;
using BoardGame.Library.Concrete;
using BoardGame.Library.Concrete.NoughtsAndCrosses;
using NUnit.Framework;
using System;


namespace BoardGame.Tests
{
    class PlayNoughtsAndCrossesTests
    {
        NoughtsAndCrossesGame Game;
        int BoardSize;

        [SetUp]
        public void Setup()
        {
            Game = new NoughtsAndCrossesGame(new NoughtsAndCrossesBoard(), new ConsoleWriter());
            BoardSize = new NoughtsAndCrossesBoard().Size;
        }

        [Test]
        public void PlayTurn_ShouldBeWithinBoardSize()
        {
            IMove move = Game.Players[0].PlayTurn();
            Assert.Less(move.XPosition, BoardSize);
            Assert.Less(move.YPosition, BoardSize);
            move = Game.Players[0].PlayTurn();
            Assert.Less(move.XPosition, BoardSize);
            Assert.Less(move.YPosition, BoardSize);
            move = Game.Players[0].PlayTurn();
            Assert.Less(move.XPosition, BoardSize);
            Assert.Less(move.YPosition, BoardSize);
        }
    }
}
