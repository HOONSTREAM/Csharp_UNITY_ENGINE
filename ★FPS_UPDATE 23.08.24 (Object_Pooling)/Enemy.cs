using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float _speed = 5.0f;
    Vector3 dir;

    //폭발효과를 만드는 공장 주소
    public GameObject explosionFactory;
    void Start()
    {
        int RandValue = UnityEngine.Random.Range(0, 10); // 0부터 9까지의 10개의 값 중에 랜덤으로 한개 가져온다.

        if (RandValue < 3)
        {
           GameObject Target = GameObject.Find("Player");
           dir = Target.transform.position - transform.position; // C = B-A A가 B를향해 향하는 벡터의 빼기 

           dir.Normalize();
        }
        else
        {
            dir = Vector3.down; //정규화 된 벡터
        }

    }

    
    void Update()
    {
        transform.position += dir * _speed * Time.deltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        ScoreManager.Instance.Score++; //싱글톤 객체로 관리 

        GameObject explosion = Instantiate(explosionFactory); //폭발효과 객체 실체화 
        explosion.transform.position = transform.position; //터지는 곳은 당연히 Enemy가 마지막으로 존재하던 포지션 


        //Debug TODO 
        if (collision.gameObject.name.Contains("bullet"))
        {
            collision.gameObject.SetActive(false);
        }

        else
        {
            Destroy(collision.gameObject);
        }
       
        Destroy(gameObject); //클래스내부 내 오브젝트 (Enemy) 파괴

    }

}
