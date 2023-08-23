using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour //컴포넌트로 사용
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
