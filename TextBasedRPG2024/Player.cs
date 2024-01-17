using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG2024
{
    public class Player
    {
        public int posX = 5;
        public int posY = 2;

        public char playerChar = 'P';

        public HealthSystem healthSystem;
        public Map map;
        public Enemy enemy;

        public Player()
        {
            healthSystem = new HealthSystem(100);
        }

        public void PlayerMovement()
        {
            map = new Map();

            ConsoleKeyInfo input = Console.ReadKey();

            int dirx = 0, diry = 0;

            if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow) diry = -1;
            else if (input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow) diry = 1;
            else if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow) dirx = -1;
            else if (input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow) dirx = 1;
            else if (input.Key == ConsoleKey.Spacebar) return;

            if (dirx != 0 || diry != 0)
            {
            
                int newX = posX + dirx;
                int newY = posY + diry;

                if (map.checkBoundaries(newX, newY))
                {
                    if (newX == enemy.posX && newY == enemy.posY)
                    {
                        if (enemy.healthSystem.health != 0)
                            enemy.healthSystem.TakeDamage(5);
                        else
                        {
                            posX = newX;
                            posY = newY;
                            
                            char landedChar = map.mapContent[posY, posX];
                            
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
}
