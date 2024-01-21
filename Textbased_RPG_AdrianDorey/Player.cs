using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPG2024;

namespace Textbased_RPG_AdrianDorey
{
    internal class Player : GameObject
    {
        public char playerChar = 'P';
        public HealthSystem healthSystem;
        public BuildMap buildMap;
        public Enemy enemy0;
        
        public Player()
        {
            healthSystem = new HealthSystem();
            healthSystem.health = 100;
        }

        public void PlayerMovement()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            int dirx = 0, diry = 0;

            if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow) diry = -1;
            else if (input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow) diry = 1;
            else if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow) dirx = -1;
            else if (input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow) dirx = 1;
            else if (input.Key == ConsoleKey.Spacebar) return;

            if (dirx != 0 || diry != 0)
            {
                int newX = pos.x + dirx;
                int newY = pos.y + diry;

                if (buildMap.checkBoundaries(newX, newY))
                {
                    if (enemy0.pos.x == newX && enemy0.pos.y == newY)
                    {
                        if (enemy0.healthSystem.health != 0)
                            enemy0.healthSystem.TakeDamage(10);

                        else
                        {
                            pos.x = newX;
                            pos.y = newY;

                            char landedChar = buildMap.MapContent[pos.y, pos.x];
                            if (landedChar == 'V')
                                healthSystem.health -= 5;
                        }
                    }

                    else
                    {
                        pos.x = newX;
                        pos.y = newY;

                        char landedChar = buildMap.MapContent[pos.y, pos.x];
                        if (landedChar == 'V')
                        {
                            healthSystem.health -= 5;
                        }
                    }
                }
            }
        }
    }
}