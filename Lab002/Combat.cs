using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Lab002
{
    internal class Combat
    {
        public void CombatTurn(Enemy attacker, Enemy defender)
        {
            int outcome = attacker.Attack.Throw() - defender.Defence.Throw();

            if (outcome > 0)
            {
                defender.HP -= outcome;
                Console.ForegroundColor = ConsoleColor.Red;
                CombatLog(attacker, defender, outcome);
            }

            if (defender.HP > 0)
            {
                outcome = defender.Attack.Throw() - attacker.Defence.Throw();

                if (outcome > 0)
                {
                    attacker.HP -= outcome;
                    Console.ForegroundColor = ConsoleColor.Green;
                    CombatLog(defender, attacker, outcome);
                }
            }
        }

        private static void CombatLog(Enemy a, Enemy b, int outcome)
        {
            Console.WriteLine($"The {a.Name} hits the {b.Name} for {outcome} points of damage. HP: {b.HP}".PadRight(150));
        }
    }
}
