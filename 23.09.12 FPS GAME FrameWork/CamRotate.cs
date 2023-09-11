using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    
    public float rotateSpeed = 200f; //회전속도 변수
    float mx = 0; //회전 값 변수
    float my = 0; //회전 값 변수

    void Start()
    {
       
    }

    
    void Update()
    {
        //마우스의 입력을 받는다.
        float mouse_x = Input.GetAxis("Mouse X"); //좌우 움직임 감지
        float mouse_y = Input.GetAxis("Mouse Y"); //상하 움직임 감지

        Vector3 dir = new Vector3(-mouse_y, mouse_x, 0);

        mx += mouse_x * rotateSpeed * Time.deltaTime;
        my += mouse_y * rotateSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -89f, 89f);

        //x축 회전값을 -90~90도 사이로 제한한다.

        transform.eulerAngles = new Vector3(-my, mx, 0);

    }
}
