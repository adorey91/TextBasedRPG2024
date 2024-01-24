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

        public void DrawMap(Player player, Enemy enemy, Item money1, Item money2, Item potion)
        {
            for (int i = 0; i < mapContent.GetLength(0); i++)
            {
                for (int j = 0; j < mapContent.GetLength(1); j++)
                {
                    if (i == player.pos.y && j == player.pos.x)
                    {
                        MapColor('H');
                        Console.Write(player.playerChar);
                        Console.ResetColor();
                    }

                    else if (i == enemy.pos.y && j == enemy.pos.x && enemy.healthSystem.health > 0)
                    {
                        MapColor('E');
                        Console.Write(enemy.enemyChar);
                        Console.ResetColor();
                    }
                    
                    else if (i == money1.pos.y && j == money1.pos.x && !money1.collected)
                    {
                        MapColor('$');
                        Console.Write(money1.moneyChar);
                        Console.ResetColor();
                    }

                    else if (i == money2.pos.y && j == money2.pos.x && !money2.collected)
                    {
                        MapColor('$');
                        Console.Write(money2.moneyChar);
                        Console.ResetColor();
                    }

                    else if (i == potion.pos.y && j == potion.pos.x && !potion.collected)
                    {
                        MapColor('L');
                        Console.Write(potion.potionChar);
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
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
                case '~':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;
                case '$':
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case 'E':
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case 'H':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 'L':
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Red;
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

            MapColor('L');
            Console.Write("L");
            Console.ResetColor();
            Console.WriteLine(" = Potion");
            Console.ResetColor();

            MapColor('$');
            Console.Write("$");
            Console.ResetColor();
            Console.WriteLine(" = Money");
            Console.ResetColor();

            MapColor('E');
            Console.Write("E");
            Console.ResetColor();
            Console.WriteLine(" = Enemy");
            Console.ResetColor();

            MapColor('H');
            Console.Write("H");
            Console.ResetColor();
            Console.WriteLine(" = Hero (Player)");
            Console.ResetColor();
        }
    }
}
