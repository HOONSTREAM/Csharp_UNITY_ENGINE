using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField]
    GameObject BulletFactory;
    [SerializeField]
    GameObject fireposition;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           Resources.Load<GameObject>("Prefabs/bullet");
           GameObject bullet = Instantiate(BulletFactory);
           bullet.transform.position = fireposition.transform.position;
        }
    }
}
