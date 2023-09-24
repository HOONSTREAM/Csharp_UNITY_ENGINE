using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EXPbar : MonoBehaviour
{
    [SerializeField]
    GameObject _player;
    [SerializeField]
    Slider _silder;

   
    PlayerStat _stat;
    Data.Stat stat;
    

    void Start()
    {
        _player = GameObject.Find("UnityChan").gameObject;
        _silder = GameObject.Find("EXPBar").gameObject.GetComponent<Slider>();

        _stat = _player.GetComponent<PlayerStat>();
       
    }
    void Update()
    {
        //TODO
        _silder.value = _stat.EXP / (float)15.0f;
        
      
    }
}
