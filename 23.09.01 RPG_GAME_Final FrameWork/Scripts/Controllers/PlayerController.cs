using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� : https://geojun.tistory.com/64

public class PlayerController : MonoBehaviour
{

    [SerializeField] 
     float _speed = 5.0f;
    /*==============================================*/
    Vector3 _DesPos;
    

    public enum PlayerState
    {
        Die,
        Moving,
        Idle,

    }

    PlayerState _state = PlayerState.Idle;
    void UpdateDie()
    {
        //�ƹ��͵� ����
    }

   

    void UpdateMoving()
    {
        Vector3 dir = _DesPos - transform.position; // ������ �����ǿ��� �÷��̾��� �������� ���� ������ ���⺤�Ͱ� ���´�.

        if (dir.magnitude < 0.00001f) // ������ ��Į���� 0�� �����ϸ� (�������� ����������)
        {
            _state = PlayerState.Idle;
        }

        else
        {
            float MoveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude); //�Ÿ�(�ð�*�ӷ�),�ּڰ�,�ִ�
            transform.position = transform.position + dir.normalized * MoveDist; // P = Po + vt(�Ÿ�)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
            //transform.LookAt(_DesPos); // �������������� �ٶ󺻴�.
        }

        //�ִϸ��̼� ó��

        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", _speed);
 
    }


    void UpdateIdle()
    {
        //�ִϸ��̼� ó��
       
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", 0);
  
    }


    void Start()
    {

        Managers.Input.MouseAction -= OnMouseClicked; //Inputmanager���� Ű�׼��� �߻��ϸ� OnMouseClicked �Լ��� ������ ���� ��û.
        Managers.Input.MouseAction += OnMouseClicked;


    }


    void Update()
    {
    
        switch (_state)
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

        }


    }

    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (_state==PlayerState.Die)
            return;

       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {
            _DesPos = hit.point;
            _state = PlayerState.Moving;

           // Debug.Log($"Camera Raycast {hit.collider.gameObject.name}");

        }


    }

}
