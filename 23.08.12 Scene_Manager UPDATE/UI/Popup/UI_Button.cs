using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
  
    enum Buttons
    {
        Point_Button
    }

    enum Texts
    {
        Point_Text,
        Score_Text
    }

    enum Gameobjects
    {
        TestObject,

    }

    enum Images
    {
        ItemIcon,

    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons)); //Button ������Ʈ�� ã�Ƽ� enum���� ���ڷ� �Ѱ��ְڴ�.
        Bind<Text>(typeof(Texts)); //Text ������Ʈ�� ã�Ƽ� enum���� ���ڷ� �Ѱ��ְڴ�.
        Bind<GameObject>(typeof(Gameobjects)); //Gameobject �� ã�Ƽ� enum ���� ���ڷ� �Ѱ��ְڴ�.
        Bind<Image>(typeof(Images));

        //��ưŬ�� �̺�Ʈ
        GetButton((int)Buttons.Point_Button).gameObject.BindEvent(OnButtonClicked);

        //�巡�� �̺�Ʈ
        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        BindEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);


    }

    int _score = 0;

    public void OnButtonClicked(PointerEventData data)
    {
       
        _score++;
        GetText((int)Texts.Score_Text).text = $"���� : {_score} ��"; // ���ʸ� ������ Text ������Ʈ �̸�, Text ������Ʈ�� ��ȯ�Ѵ�. Text������Ʈ ������ text �ڽ��� �����Ѵ�.
    }


}
