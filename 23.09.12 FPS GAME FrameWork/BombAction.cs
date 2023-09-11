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

    //        Destroy(gameObject); //�ڱ��ڽ� ����
    //    }

    //    currentTime += Time.deltaTime;
    //}
    void Start()
    {
        
    }

    
    void Update() //����źó�� �����ð��� ������ �� �������� ����, (�浹�� �����°� x) 
    {
        if (currentTime > destroytime)
        {
            GameObject effect = Instantiate(bombeffect);

            effect.transform.position = transform.position;

            Destroy(gameObject); //�ڱ��ڽ� ����
        }

        currentTime += Time.deltaTime;
    }
}
