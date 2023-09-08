using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{

    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Return,
        Damagerd,
        Die

    }

    EnemyState enemyState; 
    public float FindDistance = 8f; //플레이어 발견 범위
    public float AttackDistance = 2f; //공격 가능 범위
    public float MoveSpeed = 5f; // 이동속도
    
    Transform player;
    CharacterController cc;

    
    void Start()
    {
       enemyState = EnemyState.Idle;

        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();

    }

    
    void Update()
    {

        switch (enemyState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                break;
            case EnemyState.Return:
                break;
            case EnemyState.Damagerd:
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
        if(Vector3.Distance(transform.position, player.transform.position) > AttackDistance)
        {
            Vector3 dir = player.transform.position - transform.position;
            dir = dir.normalized;

            cc.Move(dir * MoveSpeed * Time.deltaTime);
        }
        else
        {
            enemyState = EnemyState.Attack;
            Debug.Log("Move->Attack");

        }
    }
}
