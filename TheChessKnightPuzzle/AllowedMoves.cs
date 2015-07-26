namespace TheChessKnightPuzzle
{
    public static class AllowedMoves
    {
        public static Vector UpLeft = new Vector(-1, 2);
        public static Vector UpRight = new Vector(1, 2);

        public static Vector DownLeft = new Vector(-1, -2);
        public static Vector DownRight = new Vector(1, -2);

        public static Vector LeftUp = new Vector(-2, 1);
        public static Vector LeftDown = new Vector(-2, -1);

        public static Vector RightUp = new Vector(2, 1);
        public static Vector RightDown = new Vector(2, -1);
    }
}
