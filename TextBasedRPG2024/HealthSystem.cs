using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG2024
{
    public class HealthSystem
    {
        public int health;

        public HealthSystem(int health)
        {
            this.health = health;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public void Heal(int hp)
        {
            health += hp;
        }
    }
}
