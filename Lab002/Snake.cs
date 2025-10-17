using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab002
{
    internal class Snake : Enemy
    {
        public Snake()
        {
            Symbol = 's';
            Color = ConsoleColor.Green;
            Name = "Snake";
            HP = 25;

            Attack = new Dice(3, 4, 2);
            Defence = new Dice(1, 8, 5);
        }

        public override void Update(LevelData level)
        {
            // bool canMove = true;

            Player player = (Player)level.Elements.Find(e => e is Player);

            int distanceToPlayer = player.GetDistance(X, Y);

            if (distanceToPlayer < 2)
            {
                if (player.GetDistance(X + 1, Y) >= 2 && CanMove(X + 1, Y, level.Elements))
                {
                    X += 1;
                }
                else if (player.GetDistance(X - 1, Y) >= 2 && CanMove(X - 1, Y, level.Elements))
                {
                    X -= 1;
                }
                else if (player.GetDistance(X, Y + 1) >= 2 && CanMove(X, Y + 1, level.Elements))
                {
                    Y += 1;
                }
                else if (player.GetDistance(X, Y - 1) >= 2 && CanMove(X, Y - 1, level.Elements))
                {
                    Y -= 1;
                }
            }
        }

        private static bool CanMove(int x, int y, List<LevelElement> elements)
        {
            foreach (var element in elements)
            {
                if (element.GetDistance(x, y) <= 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
