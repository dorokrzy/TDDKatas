using System.Collections.Generic;
using System.Linq;

namespace TheChessKnightPuzzle
{
    public class Knight
    {

        public Board Board { get; private set; }
        public Vector InitialPosition { get; private set; }
        public Vector CurrentPosition { get; set; }
        public Vector[] all = new[] {AllowedMoves.RightUp, AllowedMoves.UpLeft, AllowedMoves.RightDown, AllowedMoves.UpRight,
            AllowedMoves.DownLeft, AllowedMoves.DownRight, AllowedMoves.LeftDown, AllowedMoves.LeftUp };

        public bool IsOnTheBoard
        {
            get { return IsPossible(CurrentPosition); }
        }

        public bool IsPossible(Vector position) 
        {
            return position.X >= 0 && position.X < Board.DimensionX && position.Y >= 0 && position.Y < Board.DimensionY;
        }

        public bool IsPossibleAndNotVisited(Vector position) 
        {
            return position.X >= 0 && position.X < Board.DimensionX && position.Y >= 0 && position.Y < Board.DimensionY && !Board.Map[position.X, position.Y];
        }

        public Knight(Vector initialCoordintates, Board board)
        {
            InitialPosition = initialCoordintates;
            CurrentPosition = initialCoordintates;
            Board = board;
        }

        public void Reset()
        {
            CurrentPosition = InitialPosition;
        }

        public void Move(Vector move)
        {
            CurrentPosition = CurrentPosition + move;
        }

        internal void MoveBack(Vector move)
        {
            CurrentPosition = CurrentPosition - move;
        }

        public IEnumerable<Vector> GetPossibleMoves()
        {
           return all.Where(x => IsPossible(x + CurrentPosition));
        }


        public IEnumerable<Vector> GetPossibleAndNotVisited(Vector currentPosition)
        {
            return all
                .Where(x => IsPossibleAndNotVisited(x + currentPosition));
        }

        //The optimalisation is needed for bigger boards. The possible moves are sorted
        //by the number of possible moves in the next step    
        public IEnumerable<Vector> GetPossibleAndNotVisitedAndOrdered(Vector currentPosition)
        {
            return all
                .Where(x => IsPossibleAndNotVisited(x + currentPosition))
                .OrderBy(x => GetPossibleAndNotVisited(x + currentPosition).Count());
        }
    }
}
