using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour //������Ʈ�� ���
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("bullet") || other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);

            if (other.gameObject.name.Contains("bullet"))
            {
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();

                player.bullet_Pool.Add(other.gameObject);
            }

            else if (other.gameObject.name.Contains("Enemy"))
            {
                EnemyManager manager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
                manager.enemy_Pool.Add(other.gameObject);
            }
        }

        


    }

}
