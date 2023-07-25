using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"collision! {collision.gameObject.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger !{other.gameObject.name} ");

    }

    void Start()
    {
        
    }

    /*LayerMask�� �̿��Ͽ� Ư��������Ʈ�鿡 ���ؼ��� ����ĳ������ �� �� �ֵ��� �ϴ°�. �Ϲ����� ����ĳ������ ���ɺ��ϸ� ���ϰ� �����Ƿ� 
     LayerMask�� ���� �ʼ����̴�. Layer number�� ���� ��Ʈ�÷��׸� �̿��Ͽ� ���� �ܾ�� �� �ְ�, ������� Layer8���̶�� 8��°�ڸ��� ��Ʈ�� 1�� ���ָ� �ȴ�.
     ���������� Layermask mask = LayerMask.getMask("Monster"); ó�� ������ ���� �ִ�. */
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );

            int mask = (1 << 8); //LayerMask Ȱ��

            RaycastHit hit;
            Debug.DrawRay(Camera.main.transform.position, ray.direction *100.0f, Color.red,1.0f);

            if (Physics.Raycast(ray,out hit,100.0f, mask))
            {
                Debug.Log($"Camera Raycast {hit.collider.gameObject.name}");

            }
        }

        }




    }

