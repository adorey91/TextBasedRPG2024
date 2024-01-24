using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPG2024;

namespace Textbased_RPG_AdrianDorey
{
    internal class Player : GameObject
    {
        public char playerChar = 'H';
        public HealthSystem healthSystem;
        public BuildMap buildMap;
        public Enemy enemy;
        public Item money1;
        public Item money2;
        public Item potion;
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
                else if (input.Key == ConsoleKey.Spacebar) return; // using for testing, player doesn't move

                if (dirx != 0 || diry != 0)
                {
                    int newX = pos.x + dirx;
                    int newY = pos.y + diry;

                    if (buildMap.CheckBoundaries(newX, newY))
                    {
                        if(CheckEnemy(newX, newY))
                            AttackEnemy();
                        else
                        {
                            pos.x = newX;
                            pos.y = newY;

                            money1.TryCollect(newX, newY);
                            money2.TryCollect(newX, newY);
                            potion.TryCollect(newX, newY);

                            if (potion.pickedUp)
                                healthSystem.Heal(5);

                            if (buildMap.CheckFloor(newX, newY))
                                healthSystem.TakeDamage(5);
                        }
                    }
                }
            }
        }

        public bool CheckEnemy(int newX, int newY) 
        {
            return enemy.pos.x == newX && enemy.pos.y == newY && enemy.healthSystem.health != 0;
        }

        void AttackEnemy()
        {
            enemy.healthSystem.TakeDamage(10);
        }
    }
}