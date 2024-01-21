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
