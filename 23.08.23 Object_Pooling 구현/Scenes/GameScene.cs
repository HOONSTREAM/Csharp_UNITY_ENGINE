using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.UI.ShowSceneUI<UI_Inven>(); //UI_Inven ¾À »ý¼º

        for (int i = 0; i < 10; i++)
        {
            Managers.Resources.Instantiate("UnityChan");
        }

    }
    public override void Clear()
    {
        
    }

   

    
  
}
