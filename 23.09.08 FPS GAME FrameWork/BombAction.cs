using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombeffect;
    public float destroytime = 3f;
    float currentTime = 0;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(currentTime> destroytime)
    //    {
    //        GameObject effect = Instantiate(bombeffect);

    //        effect.transform.position = transform.position;

    //        Destroy(gameObject); //자기자신 제거
    //    }

    //    currentTime += Time.deltaTime;
    //}
    void Start()
    {
        
    }

    
    void Update() //수류탄처럼 일정시간이 지났을 때 터지도록 구현, (충돌시 터지는것 x) 
    {
        if (currentTime > destroytime)
        {
            GameObject effect = Instantiate(bombeffect);

            effect.transform.position = transform.position;

            Destroy(gameObject); //자기자신 제거
        }

        currentTime += Time.deltaTime;
    }
}
