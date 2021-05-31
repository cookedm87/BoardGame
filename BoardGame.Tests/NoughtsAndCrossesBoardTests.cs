using BoardGame.Library.Abstract;
using BoardGame.Library.Concrete.NoughtsAndCrosses;
using NUnit.Framework;
using System;

namespace BoardGame.Tests
{
    public class NoughtsAndCrossesBoardTests
    {
        NoughtsAndCrossesBoard Board;
        IPlayer PlayerO;
        IPlayer PlayerX;

        [SetUp]
        public void Setup()
        {
            Board = new NoughtsAndCrossesBoard();
            PlayerO = new NoughtsAndCrossesPlayer("O");
            PlayerX = new NoughtsAndCrossesPlayer("X");
        }

        [Test]
        public void AnyWinner_Column_ShouldBeTrue()
        {
            Board.Movements.Add(CreateMove(0, 0, PlayerO));
            Board.Movements.Add(CreateMove(0, 1, PlayerO));
            Board.Movements.Add(CreateMove(0, 2, PlayerO));

            Board.Movements.Add(CreateMove(1, 0, PlayerX));
            Board.Movements.Add(CreateMove(2, 0, PlayerX));

            Assert.AreEqual(true, Board.AnyWinner());
        }

        [Test]
        public void AnyWinner_Row_ShouldBeTrue()
        {
            Board.Movements.Add(CreateMove(0, 0, PlayerO));
            Board.Movements.Add(CreateMove(1, 0, PlayerO));
            Board.Movements.Add(CreateMove(2, 0, PlayerO));

            Board.Movements.Add(CreateMove(0, 1, PlayerX));
            Board.Movements.Add(CreateMove(0, 2, PlayerX));

            Assert.AreEqual(true, Board.AnyWinner());
        }

        [Test]
        public void SpaceTaken_SpaceNotFilled_ShouldBeDash()
        {
            Board.Movements.Add(CreateMove(1, 0, PlayerO));
            NoughtsAndCrossesBoard board = (NoughtsAndCrossesBoard)Board;

            Assert.AreEqual("-", board.SpaceTaken(board.BoardGameTable[1, 1]));
        }

        [Test]
        public void SpaceTaken_SpaceFilled_ShouldBePlayerO()
        {
            Board.Movements.Add(CreateMove(2, 2, PlayerO));

            Assert.AreEqual("O", Board.SpaceTaken(Board.BoardGameTable[2, 2]));
        }

        [Test]
        public void MovementValid_Valid_ShouldBeTrue()
        {
            Board.Movements.Add(CreateMove(0, 1, PlayerO));
            Board.Movements.Add(CreateMove(1, 1, PlayerX));

            IMove move = CreateMove(2, 2, PlayerO);
            Assert.AreEqual(true, Board.MovementValid(move, PlayerO));
        }

        [Test]
        public void MovementValid_SpaceTaken_ShouldBeFalse()
        {
            Board.Movements.Add(CreateMove(0, 1, PlayerO));
            Board.Movements.Add(CreateMove(1, 1, PlayerX));
            IMove move = CreateMove(1, 1, PlayerO);

            Assert.AreEqual(false, Board.MovementValid(move, PlayerO));
        }

        [Test]
        public void MovementValid_OutOfRange_ShouldBeIndexOutOfRangeException()
        {
            Board.Movements.Add(CreateMove(0, 1, PlayerO));
            Board.Movements.Add(CreateMove(1, 1, PlayerX));
            IMove move = new NoughtsAndCrossesMove() { XPosition = 4, YPosition = 3, Player = PlayerO }; 

            Assert.Throws<IndexOutOfRangeException>(() => Board.MovementValid(move, PlayerO));
        }

        private IMove CreateMove(int xPosition, int yPosition, IPlayer player)
        {
            Board.BoardGameTable[xPosition, yPosition] = player;
            return new NoughtsAndCrossesMove() { XPosition = xPosition, YPosition = yPosition, Player = player };
        }
    }
}