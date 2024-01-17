using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG2024
{
    internal class Program
    {
        static Player player;
        static Enemy enemy;
        static Item item1;
        static Item item2;
        static Map map = new Map();

        static void Main(string[] args)
        {
            player = new Player();
            enemy = new Enemy();

            map.mapInit();
            

            while(true)
            {
                Console.Clear();

                Console.WriteLine("Text Based RPG 2024");
                Console.WriteLine();

                map.DrawMap();
                map.DisplayLegend();

                //player.PlayerMovement();
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey(true);
        }

        


    }
}
