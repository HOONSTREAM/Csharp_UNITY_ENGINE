using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform Target; //목표가 될 트랜스폼 컴포넌트 
    void Start()
    {
        
    }

    
    void Update()
    {
       transform.position = Target.position;
    }
}
