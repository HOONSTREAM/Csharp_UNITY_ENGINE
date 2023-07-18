using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] // SerializeField를 사용하여 변수는 private로 감추고, UnityTool에서 직접 수정하여 사용가능.
     float _speed = 10.0f;
    
    void Start()
    {
        
    }

    
    void Update()
    {

        //Vector3에 예약된 forward,back,left,right 사용
        //transform.TransformDirection을 사용하여 Local -> World 좌표계 변환
        //InverseTransformDirection World->local 변환
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime * _speed); // Translate 함수를 이용해도 밑과 동일함(가독성향상)
        if (Input.GetKey(KeyCode.S))
            transform.position += transform.TransformDirection(Vector3.back * Time.deltaTime * _speed); // 월드를 로컬로 변환하여 position에 더해줌
        if (Input.GetKey(KeyCode.A))
            transform.position += transform.TransformDirection(Vector3.left * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.TransformDirection(Vector3.right * Time.deltaTime * _speed);

        
    }
}
