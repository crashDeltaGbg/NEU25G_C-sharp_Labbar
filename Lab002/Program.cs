namespace Lab002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LevelData level = new();

            level.Load("Level1.txt");

            Player player = (Player)level.Elements.Find(e => e is Player);

            GameOver = false;

            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"Welcome to the dungeon!");
            Thread.Sleep(1500);
            Console.Clear();

            do
            {
                int x = 0;
                int y = 0;

                bool canMove = true;

                if (player.HP > 0) player.Draw();

                foreach (var element in level.Elements)
                {
                    int distance = element.GetDistance(player.X, player.Y);
                    if (distance <= 5) element.Draw();

                    /*if (element is Enemy enemy && distance == 0)
                    {
                        int outcome = Battle(enemy.Attack.Throw(), player.Defence.Throw());

                        Console.SetCursorPosition(0, level.Rows + 1);

                        if (outcome > 0)
                        {
                            player.HP -= outcome;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"The {enemy.Name} attacks {player.Name} for {outcome} points of damage.".PadRight(100));
                        }

                        if (player.HP > 0)
                        {
                            outcome = Battle(player.Attack.Throw(), enemy.Defence.Throw());

                            if (outcome > 0)
                            {
                                enemy.HP -= outcome;
                                Console.WriteLine($"{player.Name} attacks the {enemy.Name} for {outcome} points of damage.".PadRight(100));
                            }
                        }
                    }*/
                }

                Console.SetCursorPosition(player.X, player.Y);

                player.Update(level);

                foreach (var enemy in level.Elements.OfType<Enemy>())
                {
                    Console.SetCursorPosition(enemy.X, enemy.Y);
                    Console.Write(' ');
                    if (enemy is Player) continue;
                    enemy.Update(level);
                }

                if (player.HP <= 0) GameOver = true;
            } while (!GameOver);

            if (GameOver)
            {
                Console.SetCursorPosition(0, level.Rows + 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Oh no! That's too bad.".PadRight(150));
                Console.WriteLine();
                Console.WriteLine();

                Thread.Sleep(3000);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME OVER");
            }
        }

        static public bool GameOver { get; set; }

        static public int Battle(int attack, int defence)
        {
            return attack - defence;
        }
    }
}
