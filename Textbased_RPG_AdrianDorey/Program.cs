using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Textbased_RPG_AdrianDorey
{
    internal class Program
    {
        static Player player = new Player();
        static Random random = new Random(); // makes sure that the enemies have different health amounts

        static Enemy enemy = new Enemy(random);

        static Item money1 = new Item();
        static Item money2 = new Item();
        static Item potion = new Item();


        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            BuildMap buildMap = new BuildMap();
            buildMap.mapInit();

            //positions of GameObjects
            enemy.pos.x = 2;
            enemy.pos.y = 15;
            player.pos.x = 4;
            player.pos.y = 4;
            money1.pos.x = 4;
            money1.pos.y = 6;
            money2.pos.x = 28;
            money2.pos.y = 15;
            potion.pos.x = 25;
            potion.pos.y = 4;

            //Initializing
            player.buildMap = buildMap;
            player.enemy = enemy;
            player.money1 = money1;
            player.money2 = money2;
            player.potion = potion;
            enemy.buildMap = buildMap;
            enemy.player = player;

            while (!player.gameOver)
            {
                if (enemy.healthSystem.health == 0 && money1.collected && money2.collected)
                    player.gameOver = true;
                
                WriteTitle();
                ShowHUD();

                buildMap.DrawMap(player, enemy, money1, money2, potion);
                buildMap.DisplayLegend();

                PrintGameLog();

                player.PlayerMovement();
                enemy.EnemyMovement();

            }
            if (player.healthSystem.health == 0)
                Console.WriteLine("Player has died, press any key to exit");
            else
                Console.WriteLine("Player has won!");
            Console.ReadKey();
        }

        static void PrintGameLog()
        {
            Console.WriteLine();
            Console.WriteLine("Game Log:");
            player.LogAttackText();
            player.LogPickUpText();
            enemy.LogAttackText();
            enemy.LogEnemyDeathText();
            Console.WriteLine();
        }

        static void ShowHUD()   // handles hud output
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

            if(money2.collected  == true)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(money2.moneyChar);
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void WriteTitle()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.WriteLine("Text Based RPG 2024");
            Console.WriteLine();
        }
    }
}
