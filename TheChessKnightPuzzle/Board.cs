namespace TheChessKnightPuzzle
{
    public class Board
    {
        public int DimensionX { get; private set; }
        public int DimensionY { get; private set; }
         
        public bool[,] Map {get; private set; }
 
        public Board(int x, int y)
        {
            DimensionX = x;
            DimensionY = y;

            Map = new bool[x, y];
        }

        public void MarkMove(Vector move, bool value)
        {
            Map[move.X, move.Y] = value;
        }


        public bool FieldWasVisited(Vector move)
        {
            return Map[move.X, move.Y];
        }
    }
}
