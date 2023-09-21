using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stat

{
    [SerializeField]
    protected int _exp;
    [SerializeField]
    protected int _gold;

    public int EXP { get { return _exp; } set {  _exp = value; } }
    public int Gold { get { return _gold; } set { _gold = value; } }

    private void Start()
    {
        _level = 1;
        _hp = 10;
        _maxHp = 100;
        _attack = 10;
        _defense = 5;
        _movespeed = 5.0f;
        _exp = 0;
        _gold = 0;
    }

}