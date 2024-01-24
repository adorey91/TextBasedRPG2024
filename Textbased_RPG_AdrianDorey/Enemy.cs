﻿using System;
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


        public Enemy(Random random)
        {
            healthSystem = new HealthSystem();
            int randomHealth = random.Next(40, 65);
            healthSystem.health = randomHealth;
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
                    int dx = Math.Sign(player.pos.x - pos.x);
                    int dy = Math.Sign(player.pos.y - pos.y);

                    int newEnemyX = pos.x + dx;
                    int newEnemyY = pos.y + dy;

                    if (buildMap.CheckBoundaries(newEnemyX, newEnemyY))
                    {
                        if (newEnemyX == player.pos.x && newEnemyY == player.pos.y)
                            AttackPlayer();
                        else
                        {
                            pos.x = newEnemyX;
                            pos.y = newEnemyY;

                            if (buildMap.CheckFloor(newEnemyX, newEnemyY))
                                healthSystem.TakeDamage(5);
                        }
                    }
                }
                else // randomly moves
                {
                    int Direction = randomMovement.Next(0, 4);
                    int dx = 0;
                    int dy = 0;

                    if (Direction == 0) dy = 1;
                    else if (Direction == 1) dy = -1;
                    else if (Direction == 2) dx = 1;
                    else if (Direction == 3) dx = -1;

                    if (dx != 0 || dy != 0)
                    {
                        int newEnemyX = pos.x + dx;
                        int newEnemyY = pos.y + dy;

                        while (!buildMap.CheckBoundaries(newEnemyX, newEnemyY))
                        {
                            Direction = randomMovement.Next(0, 3);

                            dx = 0;
                            dy = 0;

                            if (Direction == 0) dy = 1;
                            else if (Direction == 1) dy = -1;
                            else if (Direction == 2) dx = 1;
                            else if (Direction == 3) dx = -1;

                            newEnemyX = pos.x + dx;
                            newEnemyY = pos.y + dy;
                        }
                        if (newEnemyX == player.pos.x && newEnemyY == player.pos.y)
                            AttackPlayer();
                        else
                        {
                            pos.x = newEnemyX;
                            pos.y = newEnemyY;

                            if (buildMap.CheckFloor(newEnemyX, newEnemyY))
                                healthSystem.TakeDamage(5);
                        }
                    }
                }
            }
        }
    }
}
