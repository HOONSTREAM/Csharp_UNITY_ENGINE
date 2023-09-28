using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : Stat

{
    [SerializeField]
    protected int _exp;
    [SerializeField]
    protected int _gold;

   
    private void TextClear()
    {
        GameObject text = GameObject.Find("Text_User").gameObject;
        text.GetComponent<Text>().text = " ";
    }
   

    public int EXP //레벨업체크 까지 관리  
    { 
        
        get { return _exp; }
        
        set 
        { _exp = value;
            //레벨업체크

          int level = Level;        
            while (true)
            {
                Data.Stat stat;
                if (Managers.Data.StatDict.TryGetValue(level + 1, out stat) == false)
                    break;
                if (_exp < stat.totalexp)
                    break;
                level++;

            }
            
            if(level != Level)
            {
                Level = level;
                SetStat(Level);
                Debug.Log("Level Up!");
               GameObject go = GameObject.Find("Level_Text").gameObject;
               go.GetComponent<Text>().text = $"Lv : {Level}";
               Managers.Sound.Play("univ0007");
               GameObject text = GameObject.Find("Text_User").gameObject;
               text.GetComponent<Text>().text = "레벨이 올랐습니다.";
               Invoke("TextClear", 2.0f);
                //23.09.26 수정 (exp 초기화)
                _exp -= (int)Managers.Data.StatDict[level].totalexp;
            }
            
        } 
    
    
    
    }
    public int Gold { get { return _gold; } set { _gold = value; } }

    private void Start()
    {
        _level = 1;   
        _gold = 0;
        _exp = 0;
        SetStat(_level);
    }


    protected override void OnDead(Stat attacker)
    {
        Debug.Log("Player Dead");

    }

    public void SetStat(int level)
    {
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict; //키가 레벨 
        Data.Stat stat = dict[level];

        _hp = stat.maxHP;
        _maxHp = stat.maxHP;
        _attack = stat.attack;
        _defense = stat.defense;
        _movespeed = stat.movespeed;
       
    }

}
