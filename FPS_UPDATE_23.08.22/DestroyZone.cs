using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour //������Ʈ�� ���
{

    private void OnTriggerEnter(Collider other)
    {

        Destroy(other.gameObject);
    }

}
