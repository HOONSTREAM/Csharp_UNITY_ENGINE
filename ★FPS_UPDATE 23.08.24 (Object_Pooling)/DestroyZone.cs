using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour //������Ʈ�� ���
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("bullet"))
        {
            other.gameObject.SetActive(false);
        }

        else
        {
            Destroy(other.gameObject);
        }


    }

}
