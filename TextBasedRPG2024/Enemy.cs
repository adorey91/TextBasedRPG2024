using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG2024
{
    public class Enemy
    {
        public int posX = 10;
        public int posY = 10;

        public char enemyChar = 'E';

        public HealthSystem healthSystem;

        public Enemy()
        {
            int randomHealth = new Random().Next(40, 65);

            healthSystem = new HealthSystem(randomHealth);
        }

        public void EnemyMovement()
        {

        }
    }
}

