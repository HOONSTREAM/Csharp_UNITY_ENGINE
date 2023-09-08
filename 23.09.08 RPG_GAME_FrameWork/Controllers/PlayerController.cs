using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngineInternal;

//참고 : https://geojun.tistory.com/64

public class PlayerController : MonoBehaviour
{
    PlayerStat _stat; // 플레이어의 스텟
    Vector3 _DesPos; //목적지 포지션
    private int _mask = (1 << (int)Define.Layer.Ground | 1 << (int)Define.Layer.Monster); //레이어마스크
    GameObject LockTarget; //타겟팅 락온 된 몬스터 변수 
    bool _stopSkill = false; // 스킬사용 멈춤 변수

    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
        Skill,
    }
    [SerializeField]
    PlayerState _state = PlayerState.Idle;
    public PlayerState State
    {
        get { return _state; }
        set
        {
            _state = value;
            Animator anim = GetComponent<Animator>();

            switch (_state)
            {
                case PlayerState.Idle:
                    anim.CrossFade("WAIT", 0.1f);
                    break;
                case PlayerState.Moving:
                    anim.CrossFade("RUN", 0.1f);
                    break;
                case PlayerState.Skill:
                    anim.CrossFade("ATTACK", 0.1f);
                    break;
                case PlayerState.Die:
                    
                    break;

            }
        }
    }
    void Start()
    {
        _stat = gameObject.GetComponent<PlayerStat>();

        Managers.Input.MouseAction -= OnMouseEvent; //Inputmanager에게 키액션이 발생하면 OnMouseClicked 함수를 실행할 것을 요청.
        Managers.Input.MouseAction += OnMouseEvent;

        Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);

    }
    void Update()
    {

        switch (State)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Skill:
                UpdateSkill();
                break;

        }


    }
    void UpdateDie()
    {
        //아무것도 못함
    }
    void UpdateMoving()
    {
        if(LockTarget != null)
        {
           float distance = (_DesPos - transform.position).magnitude;
            if (distance <= 1)
            {
                State = PlayerState.Skill;
                return;

            }
        }


        Vector3 dir = _DesPos - transform.position; // 목적지 포지션에서 플레이어의 포지션을 빼면 가야할 방향벡터가 나온다.

        if (dir.magnitude < 0.5f) // 방향의 스칼라값이 0에 수렴하면 (목적지에 도착했으면)
        {
            State = PlayerState.Idle;
        }

        else
        {
            NavMeshAgent nma = gameObject.GetAddComponent<NavMeshAgent>(); //네비메시 에이전트 활용
            float MoveDist = Mathf.Clamp(_stat.MoveSpeed * Time.deltaTime, 0, dir.magnitude); //거리(시간*속력),최솟값,최댓값
                                                                                              
            nma.Move(dir.normalized * MoveDist); //포지션을 지정하는것과 달리 엄청 정밀하게 이동시켜주지 않음. 

           // transform.position = transform.position + dir.normalized * MoveDist; // P = Po + vt(거리)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);

            if (Physics.Raycast(transform.position+Vector3.up*0.5f, dir, 1.0f, LayerMask.GetMask("Block"))) //레이어마스크가 블록인경우 계속가려는 현상 정지 
            {
                if (Input.GetMouseButton(0) == false) //대신 마우스를 계속 누르는 중이라면 계속 RUN 상태를 유지한다.
                {
                    Debug.Log("Block 레이어 테스트");
                    State = PlayerState.Idle;
                }
               
                return;

            }
        }


    }
    void UpdateIdle()
    {
     
    }
    void UpdateSkill()
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
            State = PlayerState.Idle;
        }
        else
        {
            State = PlayerState.Skill;
        }

    }
    void OnMouseEvent(Define.MouseEvent evt)
    {
        switch (State)
        {
            case PlayerState.Idle:
                OnMouseEvent_IdleRUN(evt);
                break;
            case PlayerState.Moving:
                OnMouseEvent_IdleRUN(evt);
                break;
            case PlayerState.Skill:
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
                        State = PlayerState.Moving;
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


