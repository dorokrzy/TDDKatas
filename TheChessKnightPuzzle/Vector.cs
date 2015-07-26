namespace TheChessKnightPuzzle
{
    public struct Vector
    {
        public int X;
        public int Y;

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("[{0},{1}]", X, Y);
        }

        public static Vector operator +(Vector left, Vector right)
        {
            return new Vector(right.X + left.X, right.Y + left.Y);
        }

        public static Vector operator -(Vector left, Vector right)
        {
            return new Vector(left.X - right.X, left.Y - right.Y);
        }
    }
}
