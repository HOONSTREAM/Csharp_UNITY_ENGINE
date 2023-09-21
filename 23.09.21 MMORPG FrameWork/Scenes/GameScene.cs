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

        Managers.Sound.Play("������",Define.Sound.Bgm);
        Managers.UI.ShowPopupUI<UI_Button>(); //�κ��丮 

        gameObject.GetAddComponent<CursorController>();

        //Test
        GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "UnityChan");
        Camera.main.gameObject.GetAddComponent<CameraController>().SetPlayer(player);
        Managers.Game.Spawn(Define.WorldObject.Monster, "Slime");
    
    }

   

    public override void Clear()
    {
        
    }

   

    
  
}
