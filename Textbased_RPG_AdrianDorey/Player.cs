using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public Enemy enemy1;
        public Item money1;
        public Item money2;
        public bool gameOver;
        
        public Player()
        {
            healthSystem = new HealthSystem();
            healthSystem.health = 100;
        }

        public void PlayerMovement()
        {
            if (healthSystem.health == 0)
                gameOver = true;
            else
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
                        // I really don't like this. FIX
                        if(CheckEnemy(newX, newY))
                        {
                            AttackEnemy(newX, newY);
                        }
                        else
                        {
                            pos.x = newX;
                            pos.y = newY;


                            // Revisit, I know theres a better way to do this.
                            money1.TryCollect(newX, newY);
                            money2.TryCollect(newX, newY);

                            char landedChar = buildMap.MapContent[pos.y, pos.x];

                            if (landedChar == 'P')
                        {
                            healthSystem.health -= 5;
                        }
                        }
                    }
                }
            }
        }

        public bool CheckEnemy(int newX, int newY) 
        {
            return enemy0.pos.x == newX && enemy0.pos.y == newY && enemy0.healthSystem.health != 0  || enemy1.pos.x == newX && enemy1.pos.y == newY && enemy1.healthSystem.health != 0;
        }

        void AttackEnemy(int newX, int newY)
        {
            if (enemy0.pos.x == newX && enemy0.pos.y == newY && enemy0.healthSystem.health != 0)
                enemy0.healthSystem.TakeDamage(10);
            else if (enemy1.pos.x == newX && enemy1.pos.y == newY && enemy1.healthSystem.health != 0)
                enemy1.healthSystem.TakeDamage(10);
        }
    }
}