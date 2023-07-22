using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� : https://geojun.tistory.com/64

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
     float _speed = 5.0f;
    
    void Start()
    {
        Managers.Input.KeyAction += OnKeyBoard;  //Inputmanager���� Ű�׼��� �߻��ϸ� OnKeyBoard �Լ��� ������ ���� ��û.
    }


    void Update()
    {
        
    }

 void OnKeyBoard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("WŰ �Է�");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += Vector3.forward * Time.deltaTime * _speed; // Translate �Լ��� �̿��ص� �ذ� ������(���������)
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("SŰ �Է�");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.position += Vector3.back * Time.deltaTime * _speed; // ���带 ���÷� ��ȯ�Ͽ� position�� ������
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("AŰ �Է�");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("DŰ �Է�");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }

    }

}
