using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static Define;

public class GameScene : BaseScene
{

    
    protected override void Init()
    {
       
        base.Init();

        SceneType = Define.Scene.Game;
                                  
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;

        Managers.Sound.Play("¿¤ºì°¡µå",Define.Sound.Bgm);
        Managers.UI.ShowPopupUI<UI_Button>();

        gameObject.GetAddComponent<CursorController>();
    
    }

   

    public override void Clear()
    {
        
    }

   

    
  
}
