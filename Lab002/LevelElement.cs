namespace Lab002
{
    internal abstract class LevelElement
    {
        public int X { get; set; }
        public int Y { get; set; }

        public char Symbol { get; set; }

        public ConsoleColor Color { get; set; }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = Color;
            Console.Write(Symbol);
        }

        public int GetDistance(int x, int y)
        {
            x = (int)Math.Pow(Math.Abs(X - x), 2);
            y = (int)Math.Pow(Math.Abs(Y - y), 2);

            int distance = (int)Math.Round(Math.Sqrt(x + y));

            return distance;
        }
    }
}
