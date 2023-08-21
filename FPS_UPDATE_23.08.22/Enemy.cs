using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float _speed = 5.0f;
    Vector3 dir;

    //폭발 공장 주소
    public GameObject explosionFactory;
    void Start()
    {
        int RandValue = UnityEngine.Random.Range(0, 10); // 0부터 9까지의 10개의 값 중에 랜덤으로 한개 가져온다.

        if (RandValue < 3)
        {

           GameObject Target = GameObject.Find("Player");
           dir = Target.transform.position - transform.position;

           dir.Normalize();


        }
        else
        {
            dir = Vector3.down;

        }

    }

    
    void Update()
    {

        transform.position += dir * _speed * Time.deltaTime;

      
    }

    private void OnCollisionEnter(Collision collision)
    {


        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;
        Destroy(collision.gameObject); //총알파괴
        Destroy(gameObject); //클래스내부 내 오브젝트 (Enemy) 파괴

        GameObject go = GameObject.Find("ScoreManager");
        ScoreManager sc = go.GetComponent<ScoreManager>();
  
        sc.SetScore(sc.GetScore()+1); //충돌 시 점수 1점 부여 

        
       
    }

}
