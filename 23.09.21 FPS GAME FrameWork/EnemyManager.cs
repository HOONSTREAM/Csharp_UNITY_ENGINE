using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    static EnemyManager E_instance;
    public static EnemyManager EnemyInstance { get { Init(); return E_instance; } }

    public int poolsize = 10; // 오브젝트 풀 크기
    public List<GameObject> enemy_Pool; // 오브젝트 풀 배열
    public Transform[] spawnPoints; //SpawnPoint
    Transform Root; //에너미 폴더 관리 
    
    float mintime = 0.5f;
    float maxtime = 1.5f;
    float currentTime; // 현재시간
    public float createTime = 1; // 생성시간

    //적을 생성하는 팩토리
    public GameObject enemyFactory; //enemy 프리펩 등록

    

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

            createTime = UnityEngine.Random.Range(mintime, maxtime);  //적의 생성시간을 랜덤하게 다시 설정한다.

            currentTime = 0; //현재시간 0으로 초기화
        }
    }


    static void Init() //인스턴스가 null일때 발생하는 crash 방지
    {
        if (E_instance == null) // instance의 Managers 컴포넌트를 긁어오고 싶을때 null 이라면
        {
            GameObject go = GameObject.Find("EnemyManager"); // Gameobject @Managers 오브젝트를 찾아보고 null이라면

            if (go == null) // 하이라키UI에서 CreateGameobject,후 컴포넌트를 붙이는 작업을 코드로 한다.
            {
                go = new GameObject { name = "EnemyManager" };
                go.AddComponent<EnemyManager>(); //@Managers 게임 오브젝트에 Managers 컴포넌트를 붙인다.
            }
          //  DontDestroyOnLoad(go); // 이 게임오브젝트(매니저)는 마음대로 삭제할 수 없다.
            
            E_instance = go.GetComponent<EnemyManager>(); //변수 s_instance에 Managers의 컴포넌트를 할당한다.
        }
    }
}
