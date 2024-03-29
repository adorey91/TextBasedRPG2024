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
        public bool dead;
        public bool attackedByEnemy;
        public bool floorDamage;
        public bool trapDamage;
        
        public void TakeDamage(int damage)
        {
            health -= damage;
            attackedByEnemy = true;

            if (health <= 0)
            {
                health = 0;
                dead = true;
            }
        }

        public void FloorDamage(int damage)
        {
            health -= damage;
            floorDamage = true;

            if(health <= 0)
            {
                health = 0;
                dead = true;
            }
        }

        public void TrapDamage(int damage)
        {
            health -= damage;
            trapDamage = true;

            if(health <=0)
            {
                health = 0;
                dead = true;
            }
        }

        public void Heal(int hp)
        {
            health += hp;
            if (health > 100)
                health = 100;
        }
    }
}
