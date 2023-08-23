using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField]
    GameObject BulletFactory;
    [SerializeField]
    GameObject fireposition;

    public int PoolSize = 10;
    GameObject[] bullet_Pool;
    Transform Bullet_Root; // 총알공장 풀 이름
    
    void Start()
    {
        if(Bullet_Root == null)
        {
            Bullet_Root = new GameObject { name = "@Bullet_Root" }.transform;
        }
        bullet_Pool = new GameObject[PoolSize]; //탄창 생성

        for(int i = 0; i < bullet_Pool.Length; i++) 
        {
            GameObject bullet = Instantiate(BulletFactory);

            bullet_Pool[i] = bullet;
            bullet.SetActive (false);
            bullet.transform.parent = Bullet_Root; // 빈 오브젝트 (Bullet_Root) 산하에 위치시킨다. 정리개념
        }
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
          for(int i = 0; i < bullet_Pool.Length;i++)
            {
                GameObject bullet = bullet_Pool[i];
                if(bullet.activeSelf == false)
                {
                    bullet.SetActive(true);
                    bullet.transform.position = fireposition.transform.position;

                    break;
                }
            }
        }
    }
}
