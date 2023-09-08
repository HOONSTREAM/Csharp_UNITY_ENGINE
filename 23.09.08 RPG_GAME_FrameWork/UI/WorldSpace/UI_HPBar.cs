using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HPBar :UI_Base
{
    enum GameObjects
    {
        HPBar

    }

    Stat _stat;

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        _stat = transform.parent.GetComponent<Stat>();

    }

    private void Update()
    {
        Transform parent = transform.parent;
        transform.position = parent.position + Vector3.up * (parent.GetComponent<Collider>().bounds.size.y); //�ݶ��̴� ���̸�ŭ 
        transform.rotation = Camera.main.transform.rotation; //������ 

        float ratio = _stat.Hp /(float)_stat.MaxHp;

        SetHPRatio(ratio);
    }

    public void SetHPRatio(float ratio)
    {
       
        GetGameobject((int)GameObjects.HPBar).GetComponent<Slider>().value = ratio;

    }
}
