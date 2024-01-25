using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using TextBasedRPG2024;

namespace Textbased_RPG_AdrianDorey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Random random = new Random(); // makes sure that the enemies have different health amounts
            Enemy enemy = new Enemy(random);
            Item money1 = new Item();
            Item money2 = new Item();
            Item potion = new Item();
            HUD HUD = new HUD();
            GameLog log = new GameLog();
            HealthSystem healthSystem = new HealthSystem();
 
            Console.CursorVisible = false;
            BuildMap buildMap = new BuildMap();
            buildMap.mapInit();

            //Initializing
            player.Init(buildMap, enemy, money1, money2, potion);
            enemy.Init(buildMap, player, potion);
            HUD.Init(player, enemy, money1, money2);
            log.Init(player, enemy, money1, money2, potion);

            //positions of GameObjects
            player.pos = new Point2D { x = 4, y = 4 };
            enemy.pos = new Point2D { x = 30, y = 10 };
            money1.pos = new Point2D { x = 6, y = 8 };
            money2.pos = new Point2D { x = 30, y = 18 };
            potion.pos = new Point2D { x = 25, y = 4 };
            

            while (!player.gameOver)
            {
                if (enemy.healthSystem.health == 0 && money1.collected && money2.collected)
                    player.gameOver = true;
                
                WriteTitle();
                HUD.ShowHUD();
                buildMap.DrawMap(player, enemy, money1, money2, potion);
                buildMap.DisplayLegend();
                log.PrintGameLog();
                player.PlayerMovement();
                enemy.EnemyMovement();
                
            }

            if (player.healthSystem.health == 0)
                Console.WriteLine("Player has died, press any key to exit");
            else
                Console.WriteLine("Player has won! Press any key to exit");
            Console.ReadKey();
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
