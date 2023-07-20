using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1.��ġ ���� 
// 2.���� ���� (������ġ - �� ��ġ = ����) �Ÿ�(ũ��)magnitude �� ���� �� �ְ� ���� ������ ���� �� �ִ�.

public class PlayerController : MonoBehaviour
{
    [SerializeField] // SerializeField�� ����Ͽ� ������ private�� ���߰�, UnityTool���� ���� �����Ͽ� ��밡��.
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

        //Vector3�� ����� forward,back,left,right ���
        //transform.TransformDirection�� ����Ͽ� Local -> World ��ǥ�� ��ȯ
        //InverseTransformDirection World->local ��ȯ
        if (Input.GetKey(KeyCode.W)) 
        {
            Debug.Log("WŰ �Է�");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed); // Translate �Լ��� �̿��ص� �ذ� ������(���������)
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("SŰ �Է�");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.position += transform.TransformDirection(Vector3.back * Time.deltaTime * _speed); // ���带 ���÷� ��ȯ�Ͽ� position�� ������
        }
           
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("AŰ �Է�");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
             transform.position += transform.TransformDirection(Vector3.left * Time.deltaTime * _speed);
        }
            
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("DŰ �Է�");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.position += transform.TransformDirection(Vector3.right * Time.deltaTime * _speed);
        }
           

        
    }
}
