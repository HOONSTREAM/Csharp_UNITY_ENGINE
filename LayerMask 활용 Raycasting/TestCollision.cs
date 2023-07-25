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

    /*LayerMask를 이용하여 특정오브젝트들에 한해서만 레이캐스팅을 할 수 있도록 하는것. 일반적인 레이캐스팅은 성능부하를 심하게 받으므로 
     LayerMask는 거의 필수적이다. Layer number에 따라 비트플래그를 이용하여 값을 긁어올 수 있고, 예를들어 Layer8번이라면 8번째자리의 비트를 1로 켜주면 된다.
     직관적으로 Layermask mask = LayerMask.getMask("Monster"); 처럼 가져올 수도 있다. */
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );

            int mask = (1 << 8); //LayerMask 활용

            RaycastHit hit;
            Debug.DrawRay(Camera.main.transform.position, ray.direction *100.0f, Color.red,1.0f);

            if (Physics.Raycast(ray,out hit,100.0f, mask))
            {
                Debug.Log($"Camera Raycast {hit.collider.gameObject.name}");

            }
        }

        }




    }

