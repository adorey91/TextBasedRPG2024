using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Textbased_RPG_AdrianDorey
{
    internal class GameLog
    {
        public Enemy enemy;
        public Player player;
        public Item money1;
        public Item money2;
        public Item potion;

        public void Init(Player player, Enemy enemy, Item money1, Item money2, Item potion)
        {
            this.player = player;
            this.enemy = enemy;
            this.money1 = money1;
            this.money2 = money2;
            this.potion = potion;
        }

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
                if (player.healthSystem.health >= 100)
                    Console.WriteLine("Player cannot heal anymore");
                else
                    Console.WriteLine("Player picked up potion, healed " + player.healAmount);
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
