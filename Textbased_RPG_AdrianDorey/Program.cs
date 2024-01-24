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
        static HUD HUD = new HUD();
        static GameLog log = new GameLog();


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
            HUD.enemy = enemy;
            HUD.player = player;
            HUD.money1 = money1;
            HUD.money2 = money2;
            log.money1 = money1;
            log.money2 = money2;    
            log.player = player;
            log.enemy = enemy;
            log.potion = potion;

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
