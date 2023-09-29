using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerUpHandler
{
    public int slotnum;
    public Item item;
    public Image itemicon;

    public void UpdateSlotUI()
    {
        itemicon.sprite = item.itemImage;
        itemicon.gameObject.SetActive(true);
    }

    public void RemoveSlot()
    {
        item = null;
        itemicon.gameObject.SetActive(false);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bool isUse = item.Use();
        if(isUse)
        {
            PlayerInventory.Instance.RemoveItem(slotnum);
        }
    }
}
