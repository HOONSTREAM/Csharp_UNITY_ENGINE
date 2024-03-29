using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : Stat

{
    [SerializeField]
    protected int _exp;
    [SerializeField]
    protected int _gold;
    
    public GameObject Weapon;
    PlayerEquipment equipment;

    #region GUISTAT
    private void OnUpdateStatUI()
    {
        GameObject atktxt = GameObject.Find("ATKnum").gameObject;
        atktxt.GetComponent<TextMeshProUGUI>().text = Attack.ToString();
    }
    #endregion

    #region PrintUserText
    private void TextClear()
    {
        GameObject text = GameObject.Find("Text_User").gameObject;
        text.GetComponent<TextMeshProUGUI>().text = " ";
    }
   
    public void PrintUserText(string Input)
    {
        GameObject text = GameObject.Find("Text_User").gameObject;
        text.GetComponent<TextMeshProUGUI>().text = Input;
        Managers.Sound.Play("Coin", Define.Sound.Effect);
        Invoke("TextClear", 2.0f);
    }
    #endregion

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
               go.GetComponent<TextMeshProUGUI>().text = $"Lv . {Level}";
               Managers.Sound.Play("univ0007");
                PrintUserText("레벨이 올랐습니다.");
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
        equipment = GetComponent<PlayerEquipment>();
    }
    private void Update()

    {
        //TODO 성능상 좋지않다. 이벤트가 발생하면 스텟 업데이트 할수 있도록 수정해야할 듯.
        OnUpdateStatUI();
    }


    protected override void OnDead(Stat attacker)
    {
        Debug.Log("Player Dead");

    }

    #region 스텟세팅 (장착장비검사까지)

    int WeaponAttackValue = 0; //장착무기 공격스텟 저장변수
    public void SetStat(int level)
    {
        
 
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict; //키가 레벨 
        Data.Stat stat = dict[level];

        _hp = stat.maxHP;
        _maxHp = stat.maxHP;       
        _defense = stat.defense;
        _movespeed = stat.movespeed;
        _attack = stat.attack + WeaponAttackValue; 


    }

    public void SetWeaponAttackValue(int level)
    {
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict; //키가 레벨 
        Data.Stat stat = dict[level];

        WeaponAttackValue = equipment.player_equip[EquipType.Weapon].num_1;
        _attack = stat.attack + WeaponAttackValue;

    }
        

    #endregion

}
