using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab002
{
    internal class LevelData
    {
        private List<LevelElement> _elements = new();

        // private List<Enemy> _enemies = new();

        public List<LevelElement> Elements { get { return _elements; } }

        // public List<Enemy> Enemies { get { return _enemies; } }

        // public Player Player { get; set; }

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
                            // Player = new Player() { X = i, Y = top };
                            break;
                        default:
                            break;
                    }
                }
                top++;
            }

            Rows = top + 1;
        }

        /*public int GetDistance(LevelElement a, LevelElement b)
        {
            int x = (int)Math.Pow(Math.Abs(a.X - b.X), 2);
            int y = (int)Math.Pow(Math.Abs(a.Y - b.Y), 2);

            int distance = (int)Math.Round(Math.Sqrt(x + y));

            return distance;
        }*/
    }
}
