using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedRPG2024;

namespace Textbased_RPG_AdrianDorey
{
    internal class Enemy : GameObject
    {
        private Random randomMovement = new Random();
        public char enemyChar = 'E';
        public HealthSystem healthSystem;
        public BuildMap buildMap;
        public Player player;

        private int dx;
        private int dy;
        private int newX;
        private int newY;

        public Enemy(Random random)
        {
            healthSystem = new HealthSystem();
            int randomHealth = random.Next(40, 65);
            healthSystem.health = randomHealth;
        }

        public void Init(BuildMap buildMap, Player player, Item potion)
        {
            this.buildMap = buildMap;
            this.player = player;
        }

        public void AttackPlayer()
        {
            player.healthSystem.TakeDamage(10);
        }

        public void EnemyMovement()
        {
            if (healthSystem.health != 0)
            {
                int playerDistance = Math.Abs(pos.x - player.pos.x) + Math.Abs(pos.y - player.pos.y);

                if (playerDistance <= 6) //checks if the player is within 6 places
                {
                    dx = Math.Sign(player.pos.x - pos.x);
                    dy = Math.Sign(player.pos.y - pos.y);

                    newX = pos.x + dx;
                    newY = pos.y + dy;

                    if (buildMap.CheckBoundaries(newX, newY))
                    {
                        if (newX == player.pos.x && newY == player.pos.y)
                            AttackPlayer();
                        else
                        {
                            pos.x = newX;
                            pos.y = newY;
                        }
                    }
                }
                else // randomly moves
                {
                    int direction = randomMovement.Next(0, 4);
                    int dx = (direction == 2) ? 1 : (direction == 3) ? -1 : 0;
                    int dy = (direction == 0) ? 1 : (direction == 1) ? -1 : 0;

                    int newX = pos.x + dx;
                    int newY = pos.y + dy;

                    while (!buildMap.CheckBoundaries(newX, newY))
                    {
                        direction = randomMovement.Next(0, 4);
                        dx = (direction == 2) ? 1 : (direction == 3) ? -1 : 0;
                        dy = (direction == 0) ? 1 : (direction == 1) ? -1 : 0;

                        newX = pos.x + dx;
                        newY = pos.y + dy;
                    }
                    if (newX == player.pos.x && newY == player.pos.y)
                            AttackPlayer();
                    else
                    {
                        pos.x = newX;
                        pos.y = newY;
                        
                    }
                }
                buildMap.CheckFloor(newX, newY);
            }
        }
    }
}