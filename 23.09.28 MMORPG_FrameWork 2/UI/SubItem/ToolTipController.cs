using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipController : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler

{
    public ToolTip tooltip;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Item item = GetComponent<Slot>().item;
        if (item != null)
        {

            tooltip.gameObject.SetActive(true);



        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
       tooltip.gameObject.SetActive(false);
    
    
    }

  
}
