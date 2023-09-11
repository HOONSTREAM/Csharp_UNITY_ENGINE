using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject FirePosition; // �߻� ��ġ 

    public GameObject GrenadeFactory; //����ź ������ ��� 
    public GameObject bulletParticle;
    ParticleSystem ps;


    public float ThrowPower = 30f; //����ź ������ �Ŀ�
    public int weaponPower = 5; //�߻繫�� ���ݷ� 
   
    void Start()
    {
        ps = bulletParticle.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); //�߻�� ��ġ, �߻� ���� 
            RaycastHit hitinfo = new RaycastHit(); //���̰� �ε��� ����� ������ ������ ����ü ���� 

            if(Physics.Raycast(ray, out hitinfo))
            {
                if(hitinfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    EnemyFSM efsm = hitinfo.transform.gameObject.GetComponent<EnemyFSM>();
                    efsm.HitEnemy(weaponPower);
                }
                else
                {
                    bulletParticle.transform.position = hitinfo.point;
                    bulletParticle.transform.forward = hitinfo.normal; // �ǰ�����Ʈ�� forward ������ ���̰� �ε��� ������ �������Ϳ� ��ġ��Ų��. 
                    ps.Play();
                }
               
              
            }
        }
        Grenade();

    }

    void Grenade()
    {
        if (Input.GetMouseButtonUp(1))
        {
            GameObject grenade = Instantiate(GrenadeFactory);
            grenade.transform.position = FirePosition.transform.position;

            Rigidbody rb = grenade.GetComponent<Rigidbody>();

            rb.AddForce(Camera.main.transform.forward * ThrowPower, ForceMode.Impulse);

        }
    }
    void Gun()
    {

    }
}
