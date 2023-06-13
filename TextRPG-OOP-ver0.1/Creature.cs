using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_OOP_ver0._1
{
   public enum CreatureType
    {
        None,
        Player = 1,
        Monster = 2

    }
    class Creature
    {
        CreatureType type;

        protected Creature(CreatureType type)
        {
            this.type = type;

        }
        protected int hp;
        protected int attack;

        public void SetInfo(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;

        }

        public int GetHp() { return hp; }
        public int GetAttack() { return attack; }

        public void OnDamaged(int damage)
        {
            hp -= damage;
            if (hp < 0)
                hp = 0;

        }
        public bool IsDead() { return hp <= 0; }


    }
}
