using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    #region Stat
    [Serializable] //����������
    public class Stat
    {
        public int level; //Json ���ϰ� �̸��� �ٸ��� ã���� ���ϹǷ� �̸��� �� �����. 
        public int maxHP;
        public int attack;
        public int totalexp;
        public int defense;
        public float movespeed;

    }
    [Serializable]
    public class StatData : ILoader<int, Stat>
    {
        public List<Stat> stats = new List<Stat>();

        public Dictionary<int, Stat> MakeDict()
        {
            Dictionary<int, Stat> dict = new Dictionary<int, Stat>();
            foreach (Stat stat in stats)
            {
                dict.Add(stat.level, stat); //key(����),value 
            }

            return dict;
        }
    }
    #endregion

}
