using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    Animator animator;

    public float speed = 5f;
    public float gravity = -20f;
    public float jumpHeight = 2f;

    private bool isGrounded;
    private Vector3 velocity;

    void Start()
    {
        // 初始时将角色旋转到面向前方
        transform.rotation = Quaternion.identity;
        animator = GetComponent<Animator>();
   
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -5f;
        }
       

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -5f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

            
        controller.Move(velocity * Time.deltaTime);
    }
}
