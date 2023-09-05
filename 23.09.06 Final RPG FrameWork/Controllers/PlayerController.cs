using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngineInternal;

//���� : https://geojun.tistory.com/64

public class PlayerController : MonoBehaviour
{
    PlayerStat _stat;
    /*==============================================*/
    Vector3 _DesPos;
  
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
                    anim.SetFloat("speed", 0);
                    anim.SetBool("attack?", false);
                    break;
                case PlayerState.Moving:
                    anim.SetFloat("speed", _stat.MoveSpeed);
                    anim.SetBool("attack?", false);
                    break;
                case PlayerState.Skill:
                    anim.SetBool("attack?", true);
                    break;
                case PlayerState.Die:
                    anim.SetBool("attack?", false);
                    break;

            }
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

        if (dir.magnitude < 0.00001f) // ������ ��Į���� 0�� �����ϸ� (�������� ����������)
        {
            State = PlayerState.Idle;
        }

        else
        {
            float MoveDist = Mathf.Clamp(_stat.MoveSpeed * Time.deltaTime, 0, dir.magnitude); //�Ÿ�(�ð�*�ӷ�),�ּڰ�,�ִ�
            transform.position = transform.position + dir.normalized * MoveDist; // P = Po + vt(�Ÿ�)
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

    }


    void Start()
    {
        _stat = gameObject.GetComponent<PlayerStat>();
       
        Managers.Input.MouseAction -= OnMouseEvent; //Inputmanager���� Ű�׼��� �߻��ϸ� OnMouseClicked �Լ��� ������ ���� ��û.
        Managers.Input.MouseAction += OnMouseEvent;


    }

    void OnHitEvent()
    {
        Debug.Log("OnHitEvent");
        State = PlayerState.Idle;


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

   
    private int _mask = (1 << (int)Define.Layer.Ground | 1 << (int)Define.Layer.Monster);
    GameObject LockTarget; //Ÿ���� ���� �� ���� ���� 
    void OnMouseEvent(Define.MouseEvent evt)
    {
        if (State == PlayerState.Die)
            return;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool raycasthit = Physics.Raycast(ray, out hit, 100.0f, _mask);

        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        switch (evt)
        {
            case  Define.MouseEvent.PointerDown:
                {
                    if (raycasthit)
                    {
                        _DesPos = hit.point;
                        State = PlayerState.Moving;

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
                    if (LockTarget != null)
                    {
                        _DesPos = LockTarget.transform.position;
                    }
                    else
                    {
                        if (raycasthit)
                        {
                            _DesPos = hit.point;
                        }
                    }
                }
                break;
           
        }
        
        }


    }


