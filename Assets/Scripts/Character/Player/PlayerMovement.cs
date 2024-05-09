using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded; 

    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    

    Vector3 moveDirection;

    Rigidbody rb;

    public Animator animator;

    private void Update()
    {

        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        
        MyInput();
        SpeedControl();

        //handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;





        animator.SetFloat("Speed", moveDirection.magnitude);


        if (Input.GetKey("w"))
        {
           
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


   


        if (!Input.GetKey("w"))
        {
         
        }

      
    }

    private void Start()
    {
        animator = GetComponent<Animator>();


        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Time.timeScale = 1.0f;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //add force to player model
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), 0.15f);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    public void StopMoving()
    {
        animator.SetFloat("Speed", moveDirection.magnitude);
    }

    
}
