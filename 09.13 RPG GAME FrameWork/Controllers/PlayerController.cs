using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngineInternal;

//참고 : https://geojun.tistory.com/64

public class PlayerController : BaseController
{
    private int _mask = (1 << (int)Define.Layer.Ground | 1 << (int)Define.Layer.Monster); //레이어마스크
    bool _stopSkill = false; // 스킬사용 멈춤 변수
    PlayerStat _stat; // 플레이어의 스텟

    public override void Init()
    {
        _stat = gameObject.GetComponent<PlayerStat>();

        Managers.Input.MouseAction -= OnMouseEvent; //Inputmanager에게 키액션이 발생하면 OnMouseClicked 함수를 실행할 것을 요청.
        Managers.Input.MouseAction += OnMouseEvent;
        if (gameObject.GetComponentInChildren<UI_HPBar>() == null)
        {
            Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);

        }

    }

    protected override void UpdateMoving()
    {
        if(LockTarget != null)
        {
           float distance = (_DesPos - transform.position).magnitude;
            if (distance <= 1)
            {
                State = Define.State.Skill;
                return;

            }
        }


        Vector3 dir = _DesPos - transform.position; // 목적지 포지션에서 플레이어의 포지션을 빼면 가야할 방향벡터가 나온다.

        if (dir.magnitude < 0.5f) // 방향의 스칼라값이 0에 수렴하면 (목적지에 도착했으면)
        {
            State = Define.State.Idle;
        }

        else
        {
            float MoveDist = Mathf.Clamp(_stat.MoveSpeed * Time.deltaTime, 0, dir.magnitude); //거리(시간*속력),최솟값,최댓값
            transform.position = transform.position + dir.normalized * MoveDist; // P = Po + vt(거리)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);

            if (Physics.Raycast(transform.position+Vector3.up*0.5f, dir, 1.0f, LayerMask.GetMask("Block"))) //레이어마스크가 블록인경우 계속가려는 현상 정지 
            {
                if (Input.GetMouseButton(0) == false) //대신 마우스를 계속 누르는 중이라면 계속 RUN 상태를 유지한다.
                {
                    Debug.Log("Block 레이어 테스트");
                    State = Define.State.Idle;
                }
               
                return;

            }
        }


    }
  
    protected override void UpdateSkill()
    {

        if (LockTarget!=null)
        {
            Vector3 dir = LockTarget.transform.position-transform.position;
            Quaternion quat = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
  
        }
    }
    void OnHitEvent() //애니메이션 Hit event로 등록되어 있는 함수 
    {
        if (LockTarget != null)
        {
            Stat targetStat = LockTarget.GetComponent<Stat>();
            int damage = Mathf.Max(0,_stat.Attack - targetStat.Defense);
            Debug.Log($"몬스터에게 {damage} 데미지를 입혔습니다.");
            targetStat.Hp -= damage;
        }

        if (_stopSkill)
        {
            State = Define.State.Idle;
        }
        else
        {
            State = Define.State.Skill;
        }

    }
    void OnMouseEvent(Define.MouseEvent evt)
    {
        switch (State)
        {
            case Define.State.Idle:
                OnMouseEvent_IdleRUN(evt);
                break;
            case Define.State.Moving:
                OnMouseEvent_IdleRUN(evt);
                break;
            case Define.State.Skill:
                {
                    if(evt == Define.MouseEvent.PointerUp)
                    {
                        _stopSkill = true;

                    }
                }
                break;

        }

     }
    
    void OnMouseEvent_IdleRUN(Define.MouseEvent evt)
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool raycasthit = Physics.Raycast(ray, out hit, 100.0f, _mask);

        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        switch (evt)
        {
            case Define.MouseEvent.PointerDown:
                {
                    if (raycasthit)
                    {
                        _DesPos = hit.point;
                        State = Define.State.Moving;
                        _stopSkill = false;

                        if (hit.collider.gameObject.layer == (int)Define.Layer.Monster)
                        {
                            LockTarget = hit.collider.gameObject;
                            Debug.Log("몬스터 클릭");
                        }

                        else
                        {
                            LockTarget = null;
                            Debug.Log("그라운드 클릭");
                        }

                    }
                }
                break;
            case Define.MouseEvent.Press:
                {
                    if (LockTarget==null && raycasthit)
                        {
                            _DesPos = hit.point;
                        }
                }
                break;

            case Define.MouseEvent.PointerUp:
                {
                    _stopSkill = true;
                }
                
                break;

        }

    }

}


