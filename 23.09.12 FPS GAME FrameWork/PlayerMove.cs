using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    Slider HpSlider;
    [SerializeField]
    GameObject Hiteffect; //플레이어가 맞았을때 발생하는 이펙트 
    int Hp = 15;
    int MaxHp = 15;
    float MoveSpeed = 10.0f;
    float gravity = -10f;
    float yVelocity = 0;
    float JumpPower = 3f;
    CharacterController controller;
    bool IsJumping = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {

        HpSlider.value = Hp / (float)MaxHp;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        //메인카메라 기준으로 상대좌표로 변경
        dir = Camera.main.transform.TransformDirection(dir);
        //다시 바닥에 착지했는가?
        if(controller.collisionFlags == CollisionFlags.Below)
        {
            //만일 점프중이었는가?
            if (IsJumping)
            {
                IsJumping = false;
                yVelocity = 0;

            }
        }
        if(Input.GetButtonDown("Jump") && !IsJumping)
        {
            yVelocity = JumpPower;
            IsJumping = true;
        }

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        controller.Move(dir*MoveSpeed*Time.deltaTime);
        //transform.position += dir * MoveSpeed * Time.deltaTime;

        
    }

    public void DamageAction(int damage)
    {
        Hp -= damage;

        if(Hp > 0)
        {
            StartCoroutine(PlayHitEffect());
        }
    }

    IEnumerator PlayHitEffect()
    {
        Hiteffect.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Hiteffect.SetActive(false);

    }


}
