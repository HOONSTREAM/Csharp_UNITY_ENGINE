using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("���� �� ���� ���� �� �� �����ϴ�.");
        Managers.Sound.Play("UnityChan/univ0010", Define.Sound.Effect);
    }
}
