using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//참고 : https://geojun.tistory.com/64

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
     float _speed = 5.0f;
    bool _MoveToDest = false;
    Vector3 _DesPos;
    
    void Start()
    {
        Managers.Input.KeyAction -= OnKeyBoard;
        Managers.Input.KeyAction += OnKeyBoard;//Inputmanager에게 키액션이 발생하면 OnKeyBoard 함수를 실행할 것을 요청.
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

    }


    void Update()
    {
        if (_MoveToDest)// 마우스를 이용한 이동을 해야한다면
        {
            Vector3 dir = _DesPos - transform.position; // 목적지 포지션에서 플레이어의 포지션을 빼면 가야할 방향벡터가 나온다.
           
            if(dir.magnitude < 0.00001f) // 방향의 스칼라값이 0에 수렴하면 (목적지에 도착했으면)
            {
                _MoveToDest = false;
            }

           else
            {
                float MoveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
                transform.position = transform.position +dir.normalized * MoveDist;
                transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(dir),10*Time.deltaTime);
                //transform.LookAt(_DesPos); // 목적지포지션을 바라본다.
            }
        }
    }

 void OnKeyBoard()
    {
        if (Input.GetKey(KeyCode.W))
        {
           
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += Vector3.forward * Time.deltaTime * _speed; // Translate 함수를 이용해도 밑과 동일함(가독성향상)
        }

        if (Input.GetKey(KeyCode.S))
        {
            
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.position += Vector3.back * Time.deltaTime * _speed; // 월드를 로컬로 변환하여 position에 더해줌
        }

        if (Input.GetKey(KeyCode.A))
        {
           
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
        _MoveToDest = false;
    }

    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {
            _DesPos = hit.point;
            _MoveToDest = true;

            //Debug.Log($"Camera Raycast {hit.collider.gameObject.name}");

        }


    }

}
