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

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );

            RaycastHit hit;
            Debug.DrawRay(Camera.main.transform.position, ray.direction *100.0f, Color.red,1.0f);

            if (Physics.Raycast(ray,out hit,100.0f))
            {
                Debug.Log($"Camera Raycast {hit.collider.gameObject.name}");

            }
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 moupos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //    Vector3 dir = moupos - Camera.main.transform.position; // 카메라위치에서 Near 까지의 방향벡터
        //    dir = dir.normalized;

        //    RaycastHit hit;
        //    Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);

        //    if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
        //    {
        //        Debug.Log($"Camera Raycast {hit.collider.gameObject.name}");

        //    }
        }




    }

