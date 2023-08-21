using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    static EnemyManager E_instance;
    public static EnemyManager EnemyInstance { get { Init(); return E_instance; } }

    
    float mintime = 1;
    float maxtime = 5;
    float currentTime; // ����ð�
    public float createTime = 1; // �����ð�

    //���� �����ϴ� ���丮
    public GameObject enemyFactory; //enemy ������ ���

    

    void Start()
    {
   
        createTime = UnityEngine.Random.Range(mintime, maxtime);

        Init();
    }


    
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime> createTime)
        {
            GameObject enemy = Instantiate(enemyFactory);

            enemy.transform.position = transform.position; //EnemyManager �ʱ���ġ�� enemy�� ���ٳ��´�.


            createTime = UnityEngine.Random.Range(mintime, maxtime);  //���� �����ð��� �����ϰ� �ٽ� �����Ѵ�.

            currentTime = 0; //����ð� 0���� �ʱ�ȭ
        }
    }


    static void Init() //�ν��Ͻ��� null�϶� �߻��ϴ� crash ����
    {
        if (E_instance == null) // instance�� Managers ������Ʈ�� �ܾ���� ������ null �̶��
        {
            GameObject go = GameObject.Find("EnemyManager"); // Gameobject @Managers ������Ʈ�� ã�ƺ��� null�̶��

            if (go == null) // ���̶�ŰUI���� CreateGameobject,�� ������Ʈ�� ���̴� �۾��� �ڵ�� �Ѵ�.
            {
                go = new GameObject { name = "EnemyManager" };
                go.AddComponent<EnemyManager>(); //@Managers ���� ������Ʈ�� Managers ������Ʈ�� ���δ�.
            }
          //  DontDestroyOnLoad(go); // �� ���ӿ�����Ʈ(�Ŵ���)�� ������� ������ �� ����.
            
            E_instance = go.GetComponent<EnemyManager>(); //���� s_instance�� Managers�� ������Ʈ�� �Ҵ��Ѵ�.
        }
    }
}
