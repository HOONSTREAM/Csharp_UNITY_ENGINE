using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject FirePosition; // 발사 위치 

    public GameObject GrenadeFactory; //수류탄 프리펩 등록 
    public GameObject bulletParticle;
    ParticleSystem ps;


    public float ThrowPower = 30f; //수류탄 던지는 파워
    public int weaponPower = 5; //발사무기 공격력 
   
    void Start()
    {
        ps = bulletParticle.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); //발사될 위치, 발사 방향 
            RaycastHit hitinfo = new RaycastHit(); //레이가 부딪힌 대상의 정보를 저장할 구조체 변수 

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
                    bulletParticle.transform.forward = hitinfo.normal; // 피격이펙트의 forward 방향을 레이가 부딪힌 지점의 법선벡터와 일치시킨다. 
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
