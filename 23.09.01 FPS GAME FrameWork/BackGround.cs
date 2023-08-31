using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    Material material;
    [SerializeField]
    float scrollSpeed = 0.2f;

    
    void Update()
    {

        Vector2 Dir = Vector2.up;

        material.mainTextureOffset += Dir * scrollSpeed * Time.deltaTime;
        
    }
}
