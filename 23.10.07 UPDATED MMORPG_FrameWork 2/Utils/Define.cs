using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define 
{

    public enum WorldObject
    {
        Unknown,
        Player,
        Monster,

    }
    public enum State
    {
        Die,
        Moving,
        Idle,
        Skill,
    }

public enum Layer
    {
        Monster = 8,
        Ground = 9,
        Block = 10,
        NPC = 12,
        NPC1 = 13,

    }
    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,

    }

    public enum Sound
    {
        Bgm,
        Effect,
        Maxcount 

    }

    public enum UIEvent
    {
        Click,
        Drag,

    }
    public enum MouseEvent
    {
        Press,
        PointerDown,
        PointerUp,
        Click,
    }
    public enum CameraMode
    {
        QuarterView,

    }
  
}
