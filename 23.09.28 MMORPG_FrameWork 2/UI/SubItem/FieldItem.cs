using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;


// 필드아이템 관련 스크립트 
public class FieldItem : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;


    public void SetItem(Item _item)
    {
        item.itemname = _item.itemname;
        item.itemImage = _item.itemImage;
        item.itemtype = _item.itemtype;
        item.efts = _item.efts;
        image.sprite = _item.itemImage;

    }

    public Item GetItem()
    {

        return item;
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
