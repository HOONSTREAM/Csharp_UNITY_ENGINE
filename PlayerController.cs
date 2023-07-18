using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] // SerializeField�� ����Ͽ� ������ private�� ���߰�, UnityTool���� ���� �����Ͽ� ��밡��.
     float _speed = 10.0f;
    
    void Start()
    {
        
    }

    
    void Update()
    {

        //Vector3�� ����� forward,back,left,right ���
        //transform.TransformDirection�� ����Ͽ� Local -> World ��ǥ�� ��ȯ
        //InverseTransformDirection World->local ��ȯ
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime * _speed); // Translate �Լ��� �̿��ص� �ذ� ������(���������)
        if (Input.GetKey(KeyCode.S))
            transform.position += transform.TransformDirection(Vector3.back * Time.deltaTime * _speed); // ���带 ���÷� ��ȯ�Ͽ� position�� ������
        if (Input.GetKey(KeyCode.A))
            transform.position += transform.TransformDirection(Vector3.left * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.TransformDirection(Vector3.right * Time.deltaTime * _speed);

        
    }
}
