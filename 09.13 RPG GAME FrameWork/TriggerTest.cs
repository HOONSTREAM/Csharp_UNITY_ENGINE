using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("아직 이 곳을 지나 갈 수 없습니다.");
        Managers.Sound.Play("UnityChan/univ0010", Define.Sound.Effect);
    }
}
