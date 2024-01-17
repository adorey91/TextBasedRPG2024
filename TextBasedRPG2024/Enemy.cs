using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG2024
{
    internal class Enemy : GameObject
    {
        public char enemyChar = 'E';
        public HealthSystem healthSystem;

        public Enemy(Random random)
        {
            healthSystem = new HealthSystem();
            int randomHealth = random.Next(40, 65);
            healthSystem.health = randomHealth;
        }

        
    }
}

