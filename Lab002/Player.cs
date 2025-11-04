namespace Lab002
{
    internal class Player : Enemy
    {
        public Player()
        {
            Symbol = '@';
            Color = ConsoleColor.Yellow;
            Name = "Player";
            HP = 100;

            Attack = new Dice(2, 6, 2);
            Defence = new Dice(2, 6, 0);
        }

        public override void Update(LevelData level)
        {
            int x = X;
            int y = Y;

            bool canMove = true;

            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    y -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    y += 1;
                    break;
                case ConsoleKey.LeftArrow:
                    x -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    x += 1;
                    break;
                default:
                    break;
            }

            Enemy deadEnemy = null;

            foreach (var element in level.Elements)
            {
                if (element.GetDistance(x, y) == 0)
                {
                    canMove = false;

                    if (element is Enemy enemy)
                    {
                        if (enemy is Player) continue;

                        Console.SetCursorPosition(0, level.Rows + 1);

                        Combat.CombatTurn(this, enemy);

                        if (enemy.HP <= 0)
                        {
                            Console.WriteLine($"The {enemy.Name} is dead.".PadRight(150));
                            deadEnemy = enemy;
                            canMove = true;
                        }

                        Console.SetCursorPosition(X, Y);
                    }

                }
            }

            level.Elements.Remove(deadEnemy);

            Console.Write(' ');

            if (canMove)
            {
                X = x;
                Y = y;
            }
        }
    }
}
