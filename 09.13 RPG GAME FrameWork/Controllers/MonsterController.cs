using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : BaseController
{
    Stat _stat;
    [SerializeField]
    float _scanRange = 10;
    [SerializeField]
    float attackRange = 2;

    public override void Init()
    {
        _stat = gameObject.GetComponent<Stat>();
        if(gameObject.GetComponentInChildren<UI_HPBar>() == null)
        {
            Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);

        }

    }

    protected override void UpdateIdle()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            return;

        float distance = (player.transform.position - gameObject.transform.position).magnitude;
        if(distance <= _scanRange)
        {
            LockTarget = player;
            State = Define.State.Moving;
            return;

        }

        Debug.Log("Monster Idle");


    }
    protected override void UpdateDie()
    {
        Debug.Log("Monster Die");
    }
    protected override void UpdateMoving()
    {
        //공격범위
        if (LockTarget != null)
        {
            _DesPos = LockTarget.transform.position;
            float distance = (_DesPos - transform.position).magnitude;
            if (distance <= attackRange)
            {

                NavMeshAgent nma = gameObject.GetComponentInChildren<NavMeshAgent>();
                nma.SetDestination(transform.position);
                State = Define.State.Skill;
                return;

            }
        }

        //이동
        Vector3 dir = _DesPos - transform.position; // 목적지 포지션에서 플레이어의 포지션을 빼면 가야할 방향벡터가 나온다.

        if (dir.magnitude < 0.5f) // 방향의 스칼라값이 0에 수렴하면 (목적지에 도착했으면)
        {
            State = Define.State.Idle;
        }

        else
        {
            NavMeshAgent nma = gameObject.GetAddComponent<NavMeshAgent>(); //네비메시 에이전트 활용

            nma.SetDestination(_DesPos);
            nma.speed = _stat.MoveSpeed;


            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);

        }
    }
        

       
    
    protected override void UpdateSkill()
    {
        Debug.Log("Monster Skill");

        if (LockTarget != null)
        {
            Vector3 dir = LockTarget.transform.position - transform.position;
            Quaternion quat = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);

        }
    }

    void OnHitEvent()
    {
        Debug.Log("Monster Hit Event");

        if(LockTarget != null)
        {
            Stat targetStat = LockTarget.GetComponent<Stat>();
            int damage = Mathf.Max(0, _stat.Attack - targetStat.Defense);
            Debug.Log($"플레이어에게 {damage} 데미지를 입혔습니다.");
            targetStat.Hp -= damage;

            if(targetStat.Hp > 0)
            {
                float distance = (LockTarget.transform.position - transform.position).magnitude;
                if(distance <= attackRange)
                {
                    State = Define.State.Skill;
                }
                else
                {
                    State = Define.State.Moving;
                }
            }
            else
            {
                State = Define.State.Idle;
            }
        }
        else
        {
            State = Define.State.Idle;

        }
    }
}
