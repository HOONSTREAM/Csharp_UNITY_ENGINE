using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float destroytime = 1.5f;
    float currentTime = 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(currentTime > destroytime)
        {
            Destroy(gameObject);
        }
        currentTime += Time.deltaTime;

    }
}
