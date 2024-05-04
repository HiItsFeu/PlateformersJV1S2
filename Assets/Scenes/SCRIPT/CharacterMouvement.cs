using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMouvement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 7.0f;
    private float Gravity = -15.0f;
    private float JumpHeight = 3.0f;

    //Jump
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;
    public bool isJumping = false;
    
    //Dash
    public float dash = 5.0f;
    public bool CanDash = true;
    public bool isDashing;
    public float dashingCD = 1f;


    Vector2 velocity;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");

        Vector2 move = transform.right * x;

        controller.Move(move * speed * Time.deltaTime);

        if(CanDash==true)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                if(dashingCD>0)
                {
                    dashingCD = 1f;
                    isDashing = true;
                }
            } 
        }
        else
        {
            CanDash = false;
        }

        if(isDashing == true)
        {
            Dash();
            if(dashingCD <= 0)
            {
                isDashing = false;
                CanDash = true;
            }
        }
        
        if (isJumping==false && isGrounded)
        {
            if(Input.GetButton("Jump"))
            {
                Jump();
            }
        }
        if(isGrounded && isJumping==true)
        {
            isJumping=false;
        }
        velocity.y += Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        isGrounded = false;
        isJumping = true;
        velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
    }

    private void Dash()
    {
        CanDash = false;
        velocity.x = Mathf.Sqrt(speed * 5f);
        dashingCD -= Time.deltaTime;
    }


}
