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
            Debug.Log("���ӿ� �����մϴ�.");
            SceneManager.LoadScene("GameZone");
        }
    }
}
