using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    static EnemyManager E_instance;
    public static EnemyManager EnemyInstance { get { Init(); return E_instance; } }

    public int poolsize = 10; // ������Ʈ Ǯ ũ��
    public List<GameObject> enemy_Pool; // ������Ʈ Ǯ �迭
    public Transform[] spawnPoints; //SpawnPoint
    Transform Root; //���ʹ� ���� ���� 
    
    float mintime = 0.5f;
    float maxtime = 1.5f;
    float currentTime; // ����ð�
    public float createTime = 1; // �����ð�

    //���� �����ϴ� ���丮
    public GameObject enemyFactory; //enemy ������ ���

    

    void Start()
    {
        if (Root == null)
            Root = new GameObject() { name = "@Enemy_Root" }.transform;
   
        createTime = UnityEngine.Random.Range(mintime, maxtime);

        Init();

        enemy_Pool = new List<GameObject>();

        for(int i = 0; i < poolsize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);

            enemy_Pool.Add(enemy);
            
            enemy.SetActive(false);

            enemy.transform.parent = Root;

        }
        
    }


    
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime> createTime)
        {
            if (enemy_Pool.Count > 0)
            {
                GameObject enemy = enemy_Pool[0];
                enemy_Pool.Remove(enemy);

                enemy.SetActive(true);

                int index = Random.Range(0, spawnPoints.Length);


                enemy.transform.position = spawnPoints[index].position;
            }

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
