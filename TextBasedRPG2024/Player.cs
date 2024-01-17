using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG2024
{
    internal class Player : GameObject
    {
        public char playerChar = 'P';
        public HealthSystem healthSystem;

        public MapBuild map;
        public Enemy enemy;


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

                int newX = position.x + dirx;
                int newY = position.y + diry;

                if (map.checkBoundaries(newX, newY))
                {
                    if (newX == enemy.position.x && newY == enemy.position.y)
                    {
                        if (enemy.healthSystem.health != 0)
                            enemy.healthSystem.TakeDamage(5);
                        else
                        {
                            position.x = newX;
                            position.y = newY;

                            char landedChar = map.mapContent[position.y, position.x];

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
