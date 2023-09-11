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
    GameObject Hiteffect; //�÷��̾ �¾����� �߻��ϴ� ����Ʈ 
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

        //����ī�޶� �������� �����ǥ�� ����
        dir = Camera.main.transform.TransformDirection(dir);
        //�ٽ� �ٴڿ� �����ߴ°�?
        if(controller.collisionFlags == CollisionFlags.Below)
        {
            //���� �������̾��°�?
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
