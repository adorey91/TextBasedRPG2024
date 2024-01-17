using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG2024
{
    internal class MapBuild
    {
        public char[,] mapContent;  // holds the map file
        public Player player;
        public Enemy enemy0;

        public Item item1 = new Item();
        public Item item2 = new Item();



        public void mapInit()   // initializes map from file to mapContent
        {
            string[] lines = File.ReadAllLines("MapBuild.txt");

            mapContent = new char[lines.Length, lines[0].Length];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    mapContent[i, j] = lines[i][j];
                }
            }
        }

        public void DrawMap() // uses the map content to draw the map includes player, enemy & items
        {

            for (int i = 0; i < mapContent.GetLength(0); i++)
            {
                for (int j = 0; j < mapContent.GetLength(1); j++)
                {

                    if (i == player.position.y && j == player.position.x)
                    {
                        Console.Write(player.playerChar);
                    }
                    else if (i == enemy0.position.y && j == enemy0.position.x)
                    {

                        if (enemy0.healthSystem.health == 0)
                            return;
                        else
                            Console.Write(enemy0.enemyChar);
                    }
                    //else if (i == item1.posY && j == item1.posX)
                    //{
                    //    Console.Write(item1.itemChar);
                    //}
                    //else if (i == item2.posY && j == item2.posX)
                    //{
                    //    Console.Write(item2.itemChar);
                    //}
                    else
                    {
                        MapColor(mapContent[i, j]);
                        Console.Write(mapContent[i, j]);
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }

        public void MapColor(char c)    // handles map color
        {
            switch (c)
            {
                case '#':
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case 'V':
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case '~':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;
                case '$':
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
            }
        }

        public void DisplayLegend() // displays legend on the bottom of the map.
        {
            Console.WriteLine("Map Legend:");

            MapColor('#');
            Console.Write("#");
            Console.ResetColor();
            Console.WriteLine(" = Walls");

            MapColor('V');
            Console.Write("V");
            Console.ResetColor();
            Console.WriteLine(" = Lava");

            MapColor('~');
            Console.Write("~");
            Console.ResetColor();
            Console.WriteLine(" = Deep Water");

            MapColor('$');
            Console.Write("$");
            Console.ResetColor();
            Console.WriteLine(" = Money");
            Console.ResetColor();
        }

        public bool checkBoundaries(int x, int y) //handles player avoiding boundaries & water
        {
            return x >= 0 && x < mapContent.GetLength(1) && y >= 0 && y < mapContent.GetLength(0) && mapContent[y, x] != '#' && mapContent[y, x] != '~';
        }
    }
}