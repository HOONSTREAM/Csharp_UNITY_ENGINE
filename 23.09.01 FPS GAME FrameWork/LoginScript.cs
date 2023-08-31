using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.anyKeyDown)
        {
            Debug.Log("게임에 입장합니다.");
            SceneManager.LoadScene("GameZone");
        }
    }
}
