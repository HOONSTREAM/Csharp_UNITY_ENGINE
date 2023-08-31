using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameScene : BaseScene
{
  

    protected override void Init()
    {
       
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.UI.ShowSceneUI<UI_Inven>(); //UI_Inven ¾À »ý¼º
                                             // Managers.UI.ShowPopupUI<UI_Button>("UI_Score_Button_Test");
        Dictionary<int,Stat> dict = Managers.Data.StatDict;
     
    
    }

   

    public override void Clear()
    {
        
    }

   

    
  
}
