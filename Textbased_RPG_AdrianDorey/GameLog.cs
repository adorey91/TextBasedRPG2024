using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textbased_RPG_AdrianDorey
{
    internal class GameLog
    {
        public Enemy enemy;
        public Player player;
        public Item money1;
        public Item money2;
        public Item potion;

        public void PrintGameLog()
        {
            Console.WriteLine();
            Console.WriteLine("Game Log:");
            LogAttackText();
            LogEnemyDeathText();
            LogPickUpText();
            Console.WriteLine();
        }

        private void LogAttackText()
        {
            if (enemy.healthSystem.attacked)
            {
                Console.WriteLine("Player attacked enemy");
                enemy.healthSystem.attacked = false;
            }
            else if (player.healthSystem.attacked)
            {
                Console.WriteLine("Enemy attacked player");
                player.healthSystem.attacked = false;
            }
        }

        private void LogPickUpText()
        {
            if (money1.pickedUp || money2.pickedUp)
            {
                Console.WriteLine("Player picked up money");
                money1.pickedUp = false;
                money2.pickedUp = false;
            }
            else if (potion.pickedUp)
            {
                Console.WriteLine("Player picked up potion, healed 5");
                potion.pickedUp = false;
            }
        }

        private void LogEnemyDeathText()
        {
            if (enemy.healthSystem.dead)
            {
                Console.WriteLine("Enemy died");
                enemy.healthSystem.dead = false;
            }
        }
    }
}
