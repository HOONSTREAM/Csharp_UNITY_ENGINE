using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEffect/Consumable(�Ҹ�ǰ)/Health")]
public class Hp_Potion : ItemEffect
{
    public override bool ExecuteRole()
    {
        Debug.Log("�÷��̾��� ü���� ȸ���մϴ�.");

        return true;
    }
}
