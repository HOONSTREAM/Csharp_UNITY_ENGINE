using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//참고 : https://geojun.tistory.com/64

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
        //아무것도 못함
    }

   

    void UpdateMoving()
    {
        Vector3 dir = _DesPos - transform.position; // 목적지 포지션에서 플레이어의 포지션을 빼면 가야할 방향벡터가 나온다.

        if (dir.magnitude < 0.00001f) // 방향의 스칼라값이 0에 수렴하면 (목적지에 도착했으면)
        {
            _state = PlayerState.Idle;
        }

        else
        {
            float MoveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude); //거리(시간*속력),최솟값,최댓값
            transform.position = transform.position + dir.normalized * MoveDist; // P = Po + vt(거리)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
            //transform.LookAt(_DesPos); // 목적지포지션을 바라본다.
        }

        //애니메이션 처리

        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", _speed);
 
    }


    void UpdateIdle()
    {
        //애니메이션 처리
       
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", 0);
  
    }


    void Start()
    {

        Managers.Input.MouseAction -= OnMouseClicked; //Inputmanager에게 키액션이 발생하면 OnMouseClicked 함수를 실행할 것을 요청.
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
