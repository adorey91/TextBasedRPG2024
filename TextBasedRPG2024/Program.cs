using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG2024
{
    internal class Program
    {
        static Item item1;
        static Item item2;


        static void Main(string[] args)
        {
            MapBuild mapBuild = new MapBuild();

            Player player = new Player();
            Random random = new Random(); // makes sure that the enemies have different health amounts

            Enemy enemy0 = new Enemy(random);
            Enemy enemy1 = new Enemy(random);

            enemy0.position.x = 2;
            enemy0.position.y = 2;

            player.position.x = 4;
            player.position.y = 4;


            mapBuild.mapInit();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Text Based RPG 2024");
                Console.WriteLine();

                mapBuild.DrawMap();
                mapBuild.DisplayLegend();

               


                //player.PlayerMovement();
                Console.ReadKey(true);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey(true);
        }

        


    }
}
