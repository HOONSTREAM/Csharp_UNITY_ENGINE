using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1.위치 벡터 
// 2.방향 벡터 (상대방위치 - 내 위치 = 방향) 거리(크기)magnitude 를 얻을 수 있고 실제 방향을 얻을 수 있다.

public class PlayerController : MonoBehaviour
{
    [SerializeField] // SerializeField를 사용하여 변수는 private로 감추고, UnityTool에서 직접 수정하여 사용가능.
     float _speed = 5.0f;
    
    void Start()
    {
       
         
    }


    float _yAngle = 0.0f;
    void Update()
    {
        _yAngle += Time.deltaTime * _speed;
       // transform.Rotate(new Vector3(0.0f, Time.deltaTime * 100.0f, 0.0f));
      

       // transform.rotation = Quaternion.Euler(new Vector3(0.0f, _yAngle, 0.0f));

        //Vector3에 예약된 forward,back,left,right 사용
        //transform.TransformDirection을 사용하여 Local -> World 좌표계 변환
        //InverseTransformDirection World->local 변환
        if (Input.GetKey(KeyCode.W)) 
        {
            Debug.Log("W키 입력");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed); // Translate 함수를 이용해도 밑과 동일함(가독성향상)
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S키 입력");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.position += transform.TransformDirection(Vector3.back * Time.deltaTime * _speed); // 월드를 로컬로 변환하여 position에 더해줌
        }
           
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A키 입력");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
             transform.position += transform.TransformDirection(Vector3.left * Time.deltaTime * _speed);
        }
            
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D키 입력");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.position += transform.TransformDirection(Vector3.right * Time.deltaTime * _speed);
        }
           

        
    }
}
