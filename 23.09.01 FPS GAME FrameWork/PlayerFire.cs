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
    Transform Bullet_Root; // �Ѿ˰��� Ǯ �̸�
    
    void Start()
    {
        if(Bullet_Root == null)
        {
            Bullet_Root = new GameObject { name = "@Bullet_Root" }.transform;
        }
        bullet_Pool = new List<GameObject>(); //źâ ����

        for(int i = 0; i < PoolSize; i++) 
        {
            GameObject bullet = Instantiate(BulletFactory);

            bullet_Pool.Add(bullet);
            bullet.SetActive (false);
            bullet.transform.parent = Bullet_Root; // �� ������Ʈ (Bullet_Root) ���Ͽ� ��ġ��Ų��. ��������
        }

        //����Ǵ� �÷����� �ȵ���̵� �ϰ�� ���̽�ƽ Ȱ��ȭ
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
