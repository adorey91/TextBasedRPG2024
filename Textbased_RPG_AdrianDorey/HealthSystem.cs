﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textbased_RPG_AdrianDorey
{
    internal class HealthSystem
    {
        public int health;
        public bool attacked;
        public bool dead;

        public void TakeDamage(int damage)
        {
            health -= damage;

            if(health <= 0)
            {
                health = 0;
                dead = true;
            }
            attacked = true;
        }

        public void Heal(int hp)
        {
            health += hp;
        }
    }
}
