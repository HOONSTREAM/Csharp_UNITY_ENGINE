using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEffect/Consumable(소모품)/Health")]
public class Hp_Potion : ItemEffect
{
    public override bool ExecuteRole()
    {
        Debug.Log("플레이어의 체력을 회복합니다.");

        return true;
    }
}
