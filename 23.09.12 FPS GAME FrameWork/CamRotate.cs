using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    
    public float rotateSpeed = 200f; //ȸ���ӵ� ����
    float mx = 0; //ȸ�� �� ����
    float my = 0; //ȸ�� �� ����

    void Start()
    {
       
    }

    
    void Update()
    {
        //���콺�� �Է��� �޴´�.
        float mouse_x = Input.GetAxis("Mouse X"); //�¿� ������ ����
        float mouse_y = Input.GetAxis("Mouse Y"); //���� ������ ����

        Vector3 dir = new Vector3(-mouse_y, mouse_x, 0);

        mx += mouse_x * rotateSpeed * Time.deltaTime;
        my += mouse_y * rotateSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -89f, 89f);

        //x�� ȸ������ -90~90�� ���̷� �����Ѵ�.

        transform.eulerAngles = new Vector3(-my, mx, 0);

    }
}
