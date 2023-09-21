using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float _speed = 5.0f;
    Vector3 dir;

    //����ȿ���� ����� ���� �ּ�
    public GameObject explosionFactory;
    void OnEnable() //��ü�� Ȱ��ȭ �� �� ���� ȣ��Ǵ� Ư¡�� ���� ����������Ŭ �Լ� 
    {
        int RandValue = UnityEngine.Random.Range(0, 10); // 0���� 9������ 10���� �� �߿� �������� �Ѱ� �����´�.

        if (RandValue < 3)
        {
           GameObject Target = GameObject.Find("Player");
           dir = Target.transform.position - transform.position; // C = B-A A�� B������ ���ϴ� ������ ���� 

           dir.Normalize();
        }
        else
        {
            dir = Vector3.down; //����ȭ �� ����
        }

    }

    
    void Update()
    {
        transform.position += dir * _speed * Time.deltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        ScoreManager.Instance.Score++; //�̱��� ��ü�� ���� 

        GameObject explosion = Instantiate(explosionFactory); //����ȿ�� ��ü ��üȭ 
        explosion.transform.position = transform.position; //������ ���� �翬�� Enemy�� ���������� �����ϴ� ������ 

        if (collision.gameObject.name.Contains("bullet"))
        {
            collision.gameObject.SetActive(false);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();

            player.bullet_Pool.Add(collision.gameObject);
        }

        else
        {
            Destroy(collision.gameObject);
        }

        gameObject.SetActive(false); //enemy ��ü ��ȯ 

        GameObject go = GameObject.Find("EnemyManager");
        EnemyManager manager = go.GetComponent<EnemyManager>();
        manager.enemy_Pool.Add(gameObject);

    }

}
