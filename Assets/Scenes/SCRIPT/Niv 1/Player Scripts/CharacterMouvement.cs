using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMouvement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 7.0f;
    public float gravity = -15f;
    public float jumpHeight = 3f;
    public bool CanMoove = true;

    //Jump
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;


    Vector2 velocity;

    void Start()
    {
        CanMoove = true;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");

        Vector2 move = transform.right * x;

        velocity.y += gravity * Time.deltaTime;


        if (CanMoove==true && move != Vector2.zero)
        {
            controller.Move(move * speed * Time.deltaTime);
            controller.Move(velocity * Time.deltaTime);
            Jump();
        }
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
