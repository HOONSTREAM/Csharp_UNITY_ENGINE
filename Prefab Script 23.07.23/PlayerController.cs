using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//참고 : https://geojun.tistory.com/64

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
     float _speed = 5.0f;
    
    void Start()
    {
        Managers.Input.KeyAction += OnKeyBoard;  //Inputmanager에게 키액션이 발생하면 OnKeyBoard 함수를 실행할 것을 요청.
    }


    void Update()
    {
        
    }

 void OnKeyBoard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W키 입력");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += Vector3.forward * Time.deltaTime * _speed; // Translate 함수를 이용해도 밑과 동일함(가독성향상)
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S키 입력");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.position += Vector3.back * Time.deltaTime * _speed; // 월드를 로컬로 변환하여 position에 더해줌
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A키 입력");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D키 입력");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }

    }

}
