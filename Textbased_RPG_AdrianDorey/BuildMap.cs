using System;
using System.IO;
using System.Threading;
using TextBasedRPG2024;

namespace Textbased_RPG_AdrianDorey
{
    internal class BuildMap
    {
        private char[,] mapContent;  // holds the map file
       

        public char[,] MapContent
        {
            get { return mapContent; }
        }

        public void mapInit()   // initializes map from file to mapContent
        {
            string[] lines = File.ReadAllLines("Map.txt");

            mapContent = new char[lines.Length, lines[0].Length];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    mapContent[i, j] = lines[i][j];
                }
            }
        }

        public void DrawMap(Player player, Enemy enemy0, Enemy enemy1, Item money1, Item money2)
        {
            for (int i = 0; i < mapContent.GetLength(0); i++)
            {
                for (int j = 0; j < mapContent.GetLength(1); j++)
                {
                    if (i == player.pos.y && j == player.pos.x)
                    {
                        Console.Write(player.playerChar);

                        
                    }

                    else if (i == enemy0.pos.y && j == enemy0.pos.x && enemy0.healthSystem.health > 0)
                    {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(enemy0.enemyChar);
                            Console.ResetColor();

                        
                    }

                    else if (i == enemy1.pos.y && j == enemy1.pos.x && enemy1.healthSystem.health > 0)
                    {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(enemy1.enemyChar);
                            Console.ResetColor();

                        
                    }

                    else if (i == money1.pos.y && j == money1.pos.x && !money1.collected)
                    {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(money1.itemChar);
                            Console.ResetColor();
                    }

                    else if (i == money2.pos.y && j == money2.pos.x && !money2.collected)
                    {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(money2.itemChar);
                            Console.ResetColor();
                    }
                    
                    else
                    {
                        MapColor(mapContent[i, j]);
                        Console.Write(mapContent[i, j]);
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public bool checkBoundaries(int x, int y) //handles player avoiding boundaries & water
        {
            return x >= 0 && x < mapContent.GetLength(1) && y >= 0 && y < mapContent.GetLength(0) && mapContent[y, x] != '#' && mapContent[y, x] != '~';
        }

        

        public void MapColor(char c)    // handles map color
        {
            switch (c)
            {
                case '#':
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case 'P':
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Green;
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

            MapColor('P');
            Console.Write("P");
            Console.ResetColor();
            Console.WriteLine(" = Poison Spill");

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
    }
}
