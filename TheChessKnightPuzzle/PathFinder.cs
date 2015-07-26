using System;
using System.Collections.Generic;

namespace TheChessKnightPuzzle
{
    class PathFinder
    {
        private Knight knight;

        public List<Vector> maxPath = new List<Vector>();
        public int maxLengh;
                
        public PathFinder(Knight knight)
        {
            this.knight = knight;
            knight.Board.MarkMove(knight.InitialPosition, true);
            maxLengh = knight.Board.DimensionX * knight.Board.DimensionY - 1;
        }

        public bool FindPath()
        {
            return GetPath(new List<Vector>());           
        }

        public bool GetPath(List<Vector> moves)
        {
            if (moves.Count == maxLengh)
            {
                maxPath = moves;
                return true;
            }

            var previousPosition = knight.CurrentPosition;

            foreach (var move in knight.GetPossibleAndNotVisitedAndOrdered(knight.CurrentPosition))
            {           
                knight.Move(move);
                moves.Add(move);
                knight.Board.MarkMove(knight.CurrentPosition, true);

                if (GetPath(moves))
                    return true;

                knight.Board.MarkMove(knight.CurrentPosition, false);
                knight.CurrentPosition = previousPosition;
                moves.RemoveAt(moves.Count - 1);
            }
            return false;
        }
    
        public void Print() {
            knight.Reset();

            Console.WriteLine(maxPath.Count);

            foreach (var move in maxPath)
            {
                knight.Move(move);
                Console.WriteLine(knight.CurrentPosition.ToString());
            }
        }

    }
}
