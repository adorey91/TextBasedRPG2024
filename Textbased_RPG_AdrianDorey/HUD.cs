using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textbased_RPG_AdrianDorey
{
    internal class HUD
    {
        public Player player;
        public Enemy enemy;
        public Item money1;
        public Item money2;

        public void Init(Player player, Enemy enemy, Item money1, Item money2)
        {
            this.player = player;
            this.enemy = enemy;
            this.money1 = money1;
            this.money2 = money2;
        }
        
        public void ShowHUD()   // handles hud output
        {
            Console.WriteLine("Player Health: " + player.healthSystem.health);
            Console.WriteLine("Enemy0 Health: " + enemy.healthSystem.health);
            Console.Write("Item Picked Up: ");

            if (money1.collected == true)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(money1.moneyChar);
                Console.ResetColor();
            }

            Console.Write(' ');

            if (money2.collected == true)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(money2.moneyChar);
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
