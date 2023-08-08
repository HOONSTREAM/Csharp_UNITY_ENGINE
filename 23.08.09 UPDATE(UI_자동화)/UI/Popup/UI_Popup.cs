using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{

    public virtual void Init()
    {
        Managers.UI.SetCanvas(gameObject, true); //sort ¸¦ true·Î
    }

    public virtual void ClosePopupUI()
    {
        Managers.UI.ClosepopupUI(this);
    }
  
}
