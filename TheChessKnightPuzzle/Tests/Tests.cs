using System.Linq;
using NUnit.Framework;

namespace TheChessKnightPuzzle.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TheKnightIsOnTheBoard()
        {
            var board = new Board(8, 8);
            var initialCoordintates = new Vector(4, 4);

            var knight = new Knight(initialCoordintates, board);
            Assert.That(knight.IsOnTheBoard, Is.EqualTo(true));

            initialCoordintates = new Vector(9, 4);
            var knight2 = new Knight(initialCoordintates, board);
            Assert.That(knight2.IsOnTheBoard, Is.EqualTo(false));
        }

        [Test]
        public void TheKnightMovesWithinTheBoard()
        {
            var board = new Board(8, 8);
            var initialCoordintates = new Vector(4, 4);

            var knight = new Knight(initialCoordintates, board);
            knight.Move(AllowedMoves.UpLeft);
            Assert.That(knight.CurrentPosition, Is.EqualTo(new Vector(3, 6)));
            Assert.That(knight.IsOnTheBoard, Is.EqualTo(true));

            knight.Reset();
            knight.Move(AllowedMoves.UpRight);
            Assert.That(knight.CurrentPosition, Is.EqualTo(new Vector(5, 6)));
            Assert.That(knight.IsOnTheBoard, Is.EqualTo(true));

            knight.Reset();
            knight.Move(AllowedMoves.DownLeft);
            Assert.That(knight.CurrentPosition, Is.EqualTo(new Vector(3, 2)));
            Assert.That(knight.IsOnTheBoard, Is.EqualTo(true));

            knight.Reset();
            knight.Move(AllowedMoves.DownRight);
            Assert.That(knight.CurrentPosition, Is.EqualTo(new Vector(5, 2)));
            Assert.That(knight.IsOnTheBoard, Is.EqualTo(true));

            knight.Reset();
            knight.Move(AllowedMoves.LeftUp);
            Assert.That(knight.CurrentPosition, Is.EqualTo(new Vector(2, 5)));
            Assert.That(knight.IsOnTheBoard, Is.EqualTo(true));

            knight.Reset();
            knight.Move(AllowedMoves.LeftDown);
            Assert.That(knight.CurrentPosition, Is.EqualTo(new Vector(2, 3)));
            Assert.That(knight.IsOnTheBoard, Is.EqualTo(true));

            knight.Reset();
            knight.Move(AllowedMoves.RightDown);
            Assert.That(knight.CurrentPosition, Is.EqualTo(new Vector(6, 3)));
            Assert.That(knight.IsOnTheBoard, Is.EqualTo(true));

            knight.Reset();
            knight.Move(AllowedMoves.RightUp);
            Assert.That(knight.CurrentPosition, Is.EqualTo(new Vector(6, 5)));
            Assert.That(knight.IsOnTheBoard, Is.EqualTo(true));
        }

        [Test]
        public void TheKnightCanDoOnlyTwoMovesFromTheCorner()
        {
            var board = new Board(8, 8);
            var initialCoordintates = new Vector(0, 0);

            var knight = new Knight(initialCoordintates, board);
            knight.Move(AllowedMoves.UpLeft);
            Assert.That(knight.IsOnTheBoard, Is.EqualTo(false));

            knight.Reset();
            knight.Move(AllowedMoves.UpRight);
            Assert.That(knight.IsOnTheBoard, Is.EqualTo(true));

            knight.Reset();
            knight.Move(AllowedMoves.DownLeft);
            Assert.That(knight.IsOnTheBoard, Is.EqualTo(false));

            knight.Reset();
            knight.Move(AllowedMoves.DownRight);
            Assert.That(knight.IsOnTheBoard, Is.EqualTo(false));

            knight.Reset();
            knight.Move(AllowedMoves.LeftUp);
            Assert.That(knight.IsOnTheBoard, Is.EqualTo(false));

            knight.Reset();
            knight.Move(AllowedMoves.LeftDown);
            Assert.That(knight.IsOnTheBoard, Is.EqualTo(false));

            knight.Reset();
            knight.Move(AllowedMoves.RightDown);
            Assert.That(knight.IsOnTheBoard, Is.EqualTo(false));

            knight.Reset();
            knight.Move(AllowedMoves.RightUp);
            Assert.That(knight.IsOnTheBoard, Is.EqualTo(true));
        }

        [Test]
        public void KnightReturnsNoPossibleMoves()
        {
            var board = new Board(3, 3);
            var initialCoordintates = new Vector(1, 1);
            var knight = new Knight(initialCoordintates, board);

            Assert.That(knight.GetPossibleMoves().Count(), Is.EqualTo(0));
        }

        [Test]
        public void KnightReturnsPossibleMoves()
        {
            var board = new Board(3, 3);
            var initialCoordintates = new Vector(0, 0);
            var knight = new Knight(initialCoordintates, board);

            var possibleMoves = knight.GetPossibleMoves();
            Assert.That(possibleMoves.First(x => x.Equals(AllowedMoves.RightUp)), Is.Not.Null);
            Assert.That(possibleMoves.First(x => x.Equals(AllowedMoves.UpRight)), Is.Not.Null);
        }

        [TestCase(3, 0, 0)]
        [TestCase(3, 1, 0)]
        [TestCase(3, 1, 1)]
        [TestCase(5, 1, 0)]
        public void PathFinderDoesNotFindThePathForSmallBoard(int boardSize,int x, int y)
        {
            var board = new Board(boardSize, boardSize);
            var initialCoordintates = new Vector(x, y);
            var knight = new Knight(initialCoordintates, board);

            var pathFinder = new PathFinder(knight);

            var result = pathFinder.FindPath();
            Assert.That(result, Is.EqualTo(false));
        }

        [TestCase(6, 0, 0)]
        [TestCase(6, 2, 3)]
        [TestCase(6, 4, 4)]
        [TestCase(8, 4, 4)]
        public void PathFinderFindThePath(int boardSize, int x, int y)
        {
            var board = new Board(boardSize, boardSize);
            var initialCoordintates = new Vector(x, y);
            var knight = new Knight(initialCoordintates, board);

            var pathFinder = new PathFinder(knight);

            var result = pathFinder.FindPath();
            Assert.That(result, Is.EqualTo(true));
            pathFinder.Print();
        }
    }
}