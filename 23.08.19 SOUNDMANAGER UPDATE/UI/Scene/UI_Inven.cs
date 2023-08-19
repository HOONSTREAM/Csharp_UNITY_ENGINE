using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{ 
    enum Gameobjects
    {
        GridPanel,

    }

    void Start()
    {
        Init();

    }

    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(Gameobjects));

        GameObject gridpanel = Get<GameObject>((int)Gameobjects.GridPanel);
        foreach (Transform child in gridpanel.transform)
        {
            Managers.Resources.Destroy(child.gameObject);
        }

            //���� �κ��丮�� �����ؼ�
            for(int i = 0; i<8; i++)
            {
              GameObject item = Managers.UI.MakeSubItem<UI_Inven_Item>(parent: gridpanel.transform).gameObject;  //���ڷ� �θ�� ����


              UI_Inven_Item invenitem = item.GetAddComponent<UI_Inven_Item>(); //�����鿡 ������Ʈ �߰�
              invenitem.SetInfo($"�����{i}��");  //�̸� 

            }
        }

    }


