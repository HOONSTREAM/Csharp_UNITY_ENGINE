using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngineInternal;

//���� : https://geojun.tistory.com/64

public class PlayerController : MonoBehaviour
{
    PlayerStat _stat; // �÷��̾��� ����
    Vector3 _DesPos; //������ ������
    private int _mask = (1 << (int)Define.Layer.Ground | 1 << (int)Define.Layer.Monster); //���̾��ũ
    GameObject LockTarget; //Ÿ���� ���� �� ���� ���� 
    bool _stopSkill = false; // ��ų��� ���� ����

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

        Managers.Input.MouseAction -= OnMouseEvent; //Inputmanager���� Ű�׼��� �߻��ϸ� OnMouseClicked �Լ��� ������ ���� ��û.
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
        //�ƹ��͵� ����
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


        Vector3 dir = _DesPos - transform.position; // ������ �����ǿ��� �÷��̾��� �������� ���� ������ ���⺤�Ͱ� ���´�.

        if (dir.magnitude < 0.5f) // ������ ��Į���� 0�� �����ϸ� (�������� ����������)
        {
            State = PlayerState.Idle;
        }

        else
        {
            NavMeshAgent nma = gameObject.GetAddComponent<NavMeshAgent>(); //�׺�޽� ������Ʈ Ȱ��
            float MoveDist = Mathf.Clamp(_stat.MoveSpeed * Time.deltaTime, 0, dir.magnitude); //�Ÿ�(�ð�*�ӷ�),�ּڰ�,�ִ�
                                                                                              
            nma.Move(dir.normalized * MoveDist); //�������� �����ϴ°Ͱ� �޸� ��û �����ϰ� �̵��������� ����. 

           // transform.position = transform.position + dir.normalized * MoveDist; // P = Po + vt(�Ÿ�)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);

            if (Physics.Raycast(transform.position+Vector3.up*0.5f, dir, 1.0f, LayerMask.GetMask("Block"))) //���̾��ũ�� ����ΰ�� ��Ӱ����� ���� ���� 
            {
                if (Input.GetMouseButton(0) == false) //��� ���콺�� ��� ������ ���̶�� ��� RUN ���¸� �����Ѵ�.
                {
                    Debug.Log("Block ���̾� �׽�Ʈ");
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
    void OnHitEvent() //�ִϸ��̼� Hit event�� ��ϵǾ� �ִ� �Լ� 
    {
        if (LockTarget != null)
        {
            Stat targetStat = LockTarget.GetComponent<Stat>();
            int damage = Mathf.Max(0,_stat.Attack - targetStat.Defense);
            Debug.Log($"���Ϳ��� {damage} �������� �������ϴ�.");
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
                            Debug.Log("���� Ŭ��");
                        }

                        else
                        {
                            LockTarget = null;
                            Debug.Log("�׶��� Ŭ��");
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


