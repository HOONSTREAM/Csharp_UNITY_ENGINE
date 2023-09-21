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
    public List<GameObject> bullet_Pool;
    Transform Bullet_Root; // 총알공장 풀 이름
    
    void Start()
    {
        if(Bullet_Root == null)
        {
            Bullet_Root = new GameObject { name = "@Bullet_Root" }.transform;
        }
        bullet_Pool = new List<GameObject>(); //탄창 생성

        for(int i = 0; i < PoolSize; i++) 
        {
            GameObject bullet = Instantiate(BulletFactory);

            bullet_Pool.Add(bullet);
            bullet.SetActive (false);
            bullet.transform.parent = Bullet_Root; // 빈 오브젝트 (Bullet_Root) 산하에 위치시킨다. 정리개념
        }

        //실행되는 플랫폼이 안드로이드 일경우 조이스틱 활성화
#if UNITY_ANDROID
GameObject.Find("Joystick canvas XYBZ").SetActive(true);
#elif UNITY_EDITOR || UNITY_STANDALONE
        GameObject.Find("Joystick canvas XYBZ").SetActive(false);
#endif

    }

    
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
#endif
    }

    public void Fire()
    {
        if (bullet_Pool.Count > 0)
        {
            GameObject bullet = bullet_Pool[0];
            bullet.SetActive(true);
            bullet_Pool.Remove(bullet);

            bullet.transform.position = transform.position;
        }
    }
}
