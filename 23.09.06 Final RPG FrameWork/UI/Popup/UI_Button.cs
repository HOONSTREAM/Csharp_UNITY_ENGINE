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
        //BackGround,

    }

    enum Images
    {
        //ItemIcon,

    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons)); //Button 컴포넌트를 찾아서 enum값을 인자로 넘겨주겠다.
        Bind<Text>(typeof(Texts)); //Text 컴포넌트를 찾아서 enum값을 인자로 넘겨주겠다.
        Bind<GameObject>(typeof(Gameobjects)); //Gameobject 를 찾아서 enum 값을 인자로 넘겨주겠다.
       //Bind<Image>(typeof(Images));
       

        //버튼클릭 이벤트
        GetButton((int)Buttons.Point_Button).gameObject.BindEvent(OnButtonClicked);
      
        
        ////드래그 이벤트
        //GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        //BindEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);


    }

    int _score = 0;

    public void OnButtonClicked(PointerEventData data)
    {
       
        _score++;
        GetText((int)Texts.Score_Text).text = $"점수 : {_score} 점"; // 제너릭 형식이 Text 컴포넌트 이며, Text 컴포넌트를 반환한다. Text컴포넌트 내부의 text 박스를 수정한다.
        if (GameObject.Find("UI_Inven"))
        {
            GameObject go = GameObject.Find("UI_Inven");
            Debug.Log("인벤토리를 닫습니다.");
            GameObject.Destroy(go);

        }
        else
        {
            Debug.Log("인벤토리를 엽니다.");
            Managers.Sound.Play("Inven_Open");
            Managers.UI.ShowSceneUI<UI_Inven>(); //UI_Inven 씬 생성
        }
    }


}
