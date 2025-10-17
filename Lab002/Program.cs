using System;
using System.Numerics;
using System.Reflection.Emit;
using System.Xml.Linq;

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

            // bool gameOver = false;

            Console.CursorVisible = false;

            /*player.Draw();

            foreach (var element in level.Elements)
            {
                int distance = level.GetDistance(element, player);
                if (distance <= 5) element.Draw();
            }*/

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

                /*ConsoleKeyInfo input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        y = -1;
                        break;
                    case ConsoleKey.DownArrow:
                        y = 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        x = -1;
                        break;
                    case ConsoleKey.RightArrow:
                        x = 1;
                        break;
                    default:
                        break;
                }

                Enemy deadEnemy = null;

                foreach (var element in level.Elements)
                {
                    if (element.GetDistance(player.X + x, player.Y + y) == 0)
                    {
                        canMove = false;

                        if (element is Enemy enemy)

                            Console.SetCursorPosition(0, level.Rows + 1);

                        *//*int attack = player.Attack.Throw();
                        int defence = enemy.Defence.Throw();*//*

                        int outcome = Battle(player.Attack.Throw(), enemy.Defence.Throw());

                        if (outcome > 0)
                        {
                            enemy.HP -= outcome;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{player.Name} attacks the {enemy.Name} for {outcome} points of damage.".PadRight(100));
                        }

                        if (enemy.HP > 0)
                        {
                            outcome = Battle(enemy.Attack.Throw(), player.Defence.Throw());

                            if (outcome > 0)
                            {
                                player.HP -= outcome;

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"The {enemy.Name} attacks {player.Name} for {outcome} points of damage.".PadRight(100));
                            }
                        }

                        if (enemy.HP <= 0)
                        {
                            Console.WriteLine($"The {enemy.Name} is dead.");
                            deadEnemy = enemy;
                            canMove = true;
                            // level.Enemies.Remove(enemy);
                        }
                    }
                }

                level.Elements.Remove(deadEnemy);

                if (canMove)
                {
                    Console.SetCursorPosition(player.X, player.Y);
                    Console.Write(' ');
                    player.X += x;
                    player.Y += y;
                }*/

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
