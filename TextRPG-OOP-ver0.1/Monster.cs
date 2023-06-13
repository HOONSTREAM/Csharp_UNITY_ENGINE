using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_OOP_ver0._1
{
    public enum MonsterType
    {
        None = 0,
        Slime = 1,
        Orc = 2,
        Skeleton = 3

    }
     class Monster : Creature
    {
        protected MonsterType type = MonsterType.None;

        protected Monster(MonsterType type) : base(CreatureType.Monster) { this.type = type; }

        public MonsterType GetMonsterType() { return type; }

    }

    class Slime : Monster
    {
        public Slime() : base(MonsterType.Slime) {

            SetInfo(1000, 1);

        }
    }

    class Orc : Monster
    {
        public Orc() : base(MonsterType.Orc) {

            SetInfo(200, 2);
        }

    }

    class Skeleton : Monster
    {
        public Skeleton() : base(MonsterType.Skeleton) {

            SetInfo(150, 5);
        }

    }
}
