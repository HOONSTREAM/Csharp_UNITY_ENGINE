using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour
{

    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Return,
        Damaged,
        Die

    }

    [SerializeField]
    Slider HpSlider;

    EnemyState enemyState;
    int Hp = 15;
    int MaxHp = 15;
    
    public float FindDistance = 8f; //플레이어 발견 범위
    public float AttackDistance = 2f; //공격 가능 범위
    public float MoveSpeed = 5f; // 이동속도
    private float currentTime = 0; // 누적시간
    private float AttackDelay = 2f; //공격 딜레이 시간
    public int AttackPower = 3; // 에너미의 공격력 
    public float moveDistance = 20f; // 에너미의 이동가능 범위 
    Vector3 OriginPos; //에너미의 초기위치
    

    
    Transform player;
    CharacterController cc;

    
    void Start()
    {
        OriginPos = transform.position; //에너미의 초기위치 지정
       enemyState = EnemyState.Idle;

        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();

       


    }

    
    void Update()
    {
        HpSlider.value = Hp / (float)MaxHp; 

        switch (enemyState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return();
                break;
            case EnemyState.Damaged:
                break;
            case EnemyState.Die:
                break;

        }
        
    }

    void Idle()
    {

        if(Vector3.Distance(transform.position,player.position) < FindDistance)
        {
            enemyState = EnemyState.Move;
            Debug.Log("Idle -> Move");
        }
    }

    void Move()
    {
        if(Vector3.Distance(transform.position, player.transform.position) > moveDistance)
        {
            enemyState = EnemyState.Return;
            Debug.Log("Move -> Return");
        }
        
        else if (Vector3.Distance(transform.position, player.transform.position) > AttackDistance)
        {

            Vector3 dir = player.transform.position - transform.position;
            dir = dir.normalized;

            cc.Move(dir * MoveSpeed * Time.deltaTime);
        }
        
        
        else
        {
            enemyState = EnemyState.Attack;
            Debug.Log("Move->Attack");
            currentTime = AttackDelay; // 공격상태로 전환시 즉시공격 

        }
    }

    void Attack()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < AttackDistance) //오브젝트간의 거리계산함수
        {
            currentTime += Time.deltaTime;

            if(currentTime > AttackDelay)
            {
                player.GetComponent<PlayerMove>().DamageAction(AttackPower);
                Debug.Log("Enemy Attack");
                currentTime = 0;
            }
        }
        else // 공격범위 밖이면 재추적 실시
        {
            enemyState = EnemyState.Move;
            Debug.Log("상태전환 Attack -> Move");
            currentTime = 0;

        }
    }

    void Return()
    {
        if(Vector3.Distance(transform.position,OriginPos) > 0.1f) //초기위치에서의 거리가 0.1f이상이면 초기위치로 되돌아감
        {
            Vector3 dir = (OriginPos - transform.position).normalized;
            cc.Move(dir*MoveSpeed * Time.deltaTime);

        }

        else
        {
            transform.position = OriginPos;
            //hp=MaxHp;
            enemyState = EnemyState.Idle;
            Debug.Log("Return -> Idle");
        }
    }

    void Damaged()
    {
        StartCoroutine(DamageProcess());   
    }
    void Die()
    {
        StopAllCoroutines();
        StartCoroutine(DieProcess());
    }

    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(0.5f);

        enemyState = EnemyState.Move;
        Debug.Log("Damaged -> Move");

    }
    IEnumerator DieProcess()
    {
        yield return new WaitForSeconds(2.0f);
        Debug.Log("소멸 !");
        Destroy(gameObject);

    }

    public void HitEnemy(int hitpower)
    {
        if(enemyState == EnemyState.Damaged || enemyState == EnemyState.Die || enemyState == EnemyState.Return)
        {
            return;
        }
        Hp -= hitpower;

        if (Hp > 0)
        {
            enemyState = EnemyState.Damaged;
            Debug.Log("Any State -> Damaged");
            Damaged();
        }
        else
        {
            enemyState = EnemyState.Die;
            Debug.Log("AnyState -> Die");
            Die();
        }
    }

}
