using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� : https://geojun.tistory.com/64

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
     float _speed = 5.0f;
    bool _MoveToDest = false;
    Vector3 _DesPos;
    
    void Start()
    {
        Managers.Input.KeyAction -= OnKeyBoard;
        Managers.Input.KeyAction += OnKeyBoard;//Inputmanager���� Ű�׼��� �߻��ϸ� OnKeyBoard �Լ��� ������ ���� ��û.
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

    }


    void Update()
    {
        if (_MoveToDest)// ���콺�� �̿��� �̵��� �ؾ��Ѵٸ�
        {
            Vector3 dir = _DesPos - transform.position; // ������ �����ǿ��� �÷��̾��� �������� ���� ������ ���⺤�Ͱ� ���´�.
           
            if(dir.magnitude < 0.00001f) // ������ ��Į���� 0�� �����ϸ� (�������� ����������)
            {
                _MoveToDest = false;
            }

           else
            {
                float MoveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
                transform.position = transform.position +dir.normalized * MoveDist;
                transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(dir),10*Time.deltaTime);
                //transform.LookAt(_DesPos); // �������������� �ٶ󺻴�.
            }
        }
    }

 void OnKeyBoard()
    {
        if (Input.GetKey(KeyCode.W))
        {
           
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += Vector3.forward * Time.deltaTime * _speed; // Translate �Լ��� �̿��ص� �ذ� ������(���������)
        }

        if (Input.GetKey(KeyCode.S))
        {
            
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.position += Vector3.back * Time.deltaTime * _speed; // ���带 ���÷� ��ȯ�Ͽ� position�� ������
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
