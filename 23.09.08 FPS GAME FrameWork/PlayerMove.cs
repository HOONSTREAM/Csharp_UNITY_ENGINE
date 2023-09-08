using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float MoveSpeed = 7.0f;
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
}
