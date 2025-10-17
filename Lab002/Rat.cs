using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab002
{
    internal class Rat : Enemy
    {
        public Rat()
        {
            Symbol = 'r';
            Color = ConsoleColor.Red;
            Name = "Rat";
            HP = 10;

            Attack = new Dice(1, 6, 3);
            Defence = new Dice(1, 6, 1);
        }

        public override void Update(LevelData level)
        {
            Random random = new Random();

            Axis axis = (Axis)random.Next(2);

            int x = X;
            int y = Y;

            bool canMove = true;

            if (axis == Axis.X)
            {
                x = x + random.Next(3 - 1);
            }
            if (axis == Axis.Y)
            {
                y = y + random.Next(3) - 1;
            }

            foreach (var element in level.Elements)
            {
                if (element.GetDistance(x, y) == 0)
                {
                    canMove = false;

                    if (element is Player player)
                    {
                        Console.SetCursorPosition(0, level.Rows + 1);

                        Combat.CombatTurn(this, player);

                        if (player.HP <= 0) canMove = true;
                    }
                }
            }

            if (canMove)
            {
                X = x;
                Y = y;
            }
        }

        private enum Axis
        {
            X,
            Y
        }
    }
}
