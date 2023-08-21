using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float _speed = 5.0f;
    Vector3 dir;

    //���� ���� �ּ�
    public GameObject explosionFactory;
    void Start()
    {
        int RandValue = UnityEngine.Random.Range(0, 10); // 0���� 9������ 10���� �� �߿� �������� �Ѱ� �����´�.

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
        Destroy(collision.gameObject); //�Ѿ��ı�
        Destroy(gameObject); //Ŭ�������� �� ������Ʈ (Enemy) �ı�

        GameObject go = GameObject.Find("ScoreManager");
        ScoreManager sc = go.GetComponent<ScoreManager>();
  
        sc.SetScore(sc.GetScore()+1); //�浹 �� ���� 1�� �ο� 

        
       
    }

}
