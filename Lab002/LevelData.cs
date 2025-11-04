namespace Lab002
{
    internal class LevelData
    {
        private List<LevelElement> _elements = new();

        public List<LevelElement> Elements { get { return _elements; } }

        public int Rows { get; set; } = 0;

        public void Load(string filename)
        {
            string path = Path.Combine("..", "..", "..", "txt", filename);

            int top = 0;

            foreach (var line in File.ReadLines(path))
            {
                for (int i = 0; i < line.Length; i++)
                {
                    switch (line[i])
                    {
                        case '#':
                            _elements.Add(new Wall() { X = i, Y = top });
                            break;
                        case 'r':
                            _elements.Add(new Rat() { X = i, Y = top });
                            break;
                        case 's':
                            _elements.Add(new Snake() { X = i, Y = top });
                            break;
                        case '@':
                            _elements.Add(new Player() { X = i, Y = top });
                            break;
                        default:
                            break;
                    }
                }
                top++;
            }

            Rows = top + 1;
        }
    }
}
