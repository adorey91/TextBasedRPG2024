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
        public Enemy Badman1;
        public Enemy Badman2;
        public Player Hero;
        public Item money1;
        public Item money2;
        public Item potion1;
        public Item potion2;
        public Item trap;


        public void Init(Player Hero, Enemy Badman1, Enemy Badman2, Item money1, Item money2, Item potion1, Item potion2, Item trap)
        {
            this.Hero = Hero;
            this.Badman1 = Badman1;
            this.Badman2 = Badman2;
            this.money1 = money1;
            this.money2 = money2;
            this.potion1 = potion1;
            this.potion2 = potion2;
            this.trap = trap;
        }

        public void PrintGameLog()
        {
            Console.WriteLine();
            Console.WriteLine("Game Log:");
            LogAttackText();
            LogFloorTrapText();
            LogPickUpText();
            LogHealingText();
            LogEnemyDeathText();
            Console.WriteLine();
        }

        private void LogAttackText()
        {
            if (Badman1.healthSystem.attackedByEnemy)
            {
                Console.WriteLine("Player attacked Badman1");
                Badman1.healthSystem.attackedByEnemy = false;
            }
            else if (Badman2.healthSystem.attackedByEnemy)
            {
                Console.WriteLine("Player attacked Badman2");
                Badman2.healthSystem.attackedByEnemy = false;
            }
            else if (Hero.healthSystem.attackedByEnemy)
            {
                Console.WriteLine("Enemy attacked player");
                Hero.healthSystem.attackedByEnemy = false;
            }
        }

        private void LogFloorTrapText()
        {
            if (Hero.healthSystem.floorDamage)
            {
                Console.WriteLine("Player damaged by poison spill");
                Hero.healthSystem.floorDamage = false;
            }
            else if (Hero.healthSystem.trapDamage)
            {
                Console.WriteLine("Player damaged by a trap");
                trap.collected = true;
                Hero.healthSystem.trapDamage = false;
            }
            else if (Badman1.healthSystem.floorDamage || Badman2.healthSystem.floorDamage)
            {
                Console.WriteLine("Enemy damaged by poison spill");
                Badman1.healthSystem.floorDamage = false;
                Badman2.healthSystem.floorDamage = false;
            }
            else if (Badman1.healthSystem.trapDamage || Badman2.healthSystem.trapDamage)
            {
                Console.WriteLine("Enemy damaged by a trap");
                trap.collected = true;
                Badman1.healthSystem.trapDamage = false;
                Badman2.healthSystem.trapDamage = false;
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
        }

        private void LogHealingText()
        {
            if (potion1.pickedUp || potion2.pickedUp)
            {
                if (Hero.healthSystem.health < 100)
                    Console.WriteLine("Player cannot heal anymore");
                else
                    Console.WriteLine("Player picked up potion");

                potion1.pickedUp = false;
                potion2.pickedUp = false;
            }
        }

        private void LogEnemyDeathText()
        {
            if (Badman1.healthSystem.dead)
                Console.WriteLine("Badman1 died");
            else if (Badman2.healthSystem.dead)
                Console.WriteLine("Badman2 died");
        }
    }
}
