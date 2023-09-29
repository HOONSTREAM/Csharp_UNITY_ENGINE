using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�����ۺ� ������ ���� ��ũ��Ʈ 
public enum ItemType
{
    Equipment,
    Consumables,
    Etc,

}

[System.Serializable]
public class Item
{ 
    public ItemType itemtype;
    public string itemname;
    public string stat_1;
    public string stat_2;
    public string num_1;
    public string num_2;
    public string Description;
    public Sprite itemImage;
    

    public List<ItemEffect> efts;

   
    public bool Use()
    {
        bool isUsed = false;
        
        foreach (ItemEffect effect in efts) 
        {
            isUsed = effect.ExecuteRole();
        }
        return isUsed;
    }
}
