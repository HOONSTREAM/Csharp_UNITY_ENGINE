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
    
    public float FindDistance = 8f; //�÷��̾� �߰� ����
    public float AttackDistance = 2f; //���� ���� ����
    public float MoveSpeed = 5f; // �̵��ӵ�
    private float currentTime = 0; // �����ð�
    private float AttackDelay = 2f; //���� ������ �ð�
    public int AttackPower = 3; // ���ʹ��� ���ݷ� 
    public float moveDistance = 20f; // ���ʹ��� �̵����� ���� 
    Vector3 OriginPos; //���ʹ��� �ʱ���ġ
    

    
    Transform player;
    CharacterController cc;

    
    void Start()
    {
        OriginPos = transform.position; //���ʹ��� �ʱ���ġ ����
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
            currentTime = AttackDelay; // ���ݻ��·� ��ȯ�� ��ð��� 

        }
    }

    void Attack()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < AttackDistance) //������Ʈ���� �Ÿ�����Լ�
        {
            currentTime += Time.deltaTime;

            if(currentTime > AttackDelay)
            {
                player.GetComponent<PlayerMove>().DamageAction(AttackPower);
                Debug.Log("Enemy Attack");
                currentTime = 0;
            }
        }
        else // ���ݹ��� ���̸� ������ �ǽ�
        {
            enemyState = EnemyState.Move;
            Debug.Log("������ȯ Attack -> Move");
            currentTime = 0;

        }
    }

    void Return()
    {
        if(Vector3.Distance(transform.position,OriginPos) > 0.1f) //�ʱ���ġ������ �Ÿ��� 0.1f�̻��̸� �ʱ���ġ�� �ǵ��ư�
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
        Debug.Log("�Ҹ� !");
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
