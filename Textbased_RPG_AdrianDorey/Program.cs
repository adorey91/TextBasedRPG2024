using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Textbased_RPG_AdrianDorey
{
    internal class Program
    {
        static Item item1;
        static Item item2;


        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            BuildMap buildMap = new BuildMap();

            Player player = new Player();
            Random random = new Random(); // makes sure that the enemies have different health amounts

            Enemy enemy0 = new Enemy(random);
            Enemy enemy1 = new Enemy(random);

            Item money1 = new Item();
            Item money2 = new Item();

            enemy0.pos.x = 2;
            enemy0.pos.y = 2;
            player.pos.x = 4;
            player.pos.y = 4;
            money1.pos.x = 4;
            money1.pos.y = 2;
            money2.pos.x = 2;
            money2.pos.y = 4;


            buildMap.mapInit();

            player.buildMap = buildMap;

            while (true)
            {
                WriteTitle();

                buildMap.DrawMap(player, enemy0, money1, money2);
                buildMap.DisplayLegend();

                player.PlayerMovement();
                //Console.ReadKey(true);

                System.Threading.Thread.Sleep(100);
            }
        }

        static void WriteTitle()
        {
            Console.Clear();
            Console.WriteLine("Text Based RPG 2024");
            Console.WriteLine();
        }
    }
}
