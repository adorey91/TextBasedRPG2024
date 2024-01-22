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

        static Enemy enemy0 = new Enemy(random);
        static Enemy enemy1 = new Enemy(random);

        static Item money1 = new Item();
        static Item money2 = new Item();


        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            BuildMap buildMap = new BuildMap();

            
            enemy0.pos.x = 2;
            enemy0.pos.y = 10;
            enemy1.pos.x = 8;
            enemy1.pos.y = 15;
            player.pos.x = 4;
            player.pos.y = 4;
            money1.pos.x = 4;
            money1.pos.y = 6;
            money2.pos.x = 28;
            money2.pos.y = 15;


            buildMap.mapInit();

            player.buildMap = buildMap;
            player.enemy0 = enemy0;
            player.enemy1 = enemy1;
            enemy0.buildMap = buildMap;
            enemy1.buildMap = buildMap;
            enemy0.player = player;
            enemy1.player = player;
            player.money1 = money1;
            player.money2 = money2;

            while (!player.gameOver)
            {
                WriteTitle();
                ShowHUD();

                buildMap.DrawMap(player, enemy0, enemy1, money1, money2);
                buildMap.DisplayLegend();

                player.PlayerMovement();
                enemy0.EnemyMovement();
                enemy1.EnemyMovement();
            }

            Console.WriteLine("Player has died, press any key to exit");
            Console.ReadKey();
        }

        static void ShowHUD()   // handles hud output
        {
            Console.WriteLine("Player Health: " + player.healthSystem.health);
            Console.WriteLine("Enemy0 Health: " + enemy0.healthSystem.health);
            Console.WriteLine("Enemy1 Health: " + enemy1.healthSystem.health);
            Console.Write("Item Picked Up: ");

            if (money1.collected == true)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(money1.itemChar);
                Console.ResetColor();
            }

            Console.Write(' ');

            if(money2.collected  == true)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(money2.itemChar);
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
