using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float strafeSpeed = 2f;
    public float jumpForce = 600f;
    float sprintMultiplier = 1f;
    public bool isSprinting = false;
    bool isJumping = false;
    float move;
    float strafe;
    public Rigidbody rb;
    public Animator animator;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        strafe = Input.GetAxis("Horizontal");
        move = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            sprintMultiplier = 2f;
        } 
        else
        {
            isSprinting = false;
            sprintMultiplier = 1f;
        }
        if (Input.GetButton("Jump")&&isGrounded)
        {
            isJumping = true;
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * move * Time.deltaTime * moveSpeed * sprintMultiplier);
        Vector3 side = new Vector3(1, 0, 0) * strafe * Time.deltaTime * strafeSpeed;
        transform.Translate(side);
        animator.SetFloat("Speed", Mathf.Abs(move*sprintMultiplier));
        if(isJumping)
        {
           
            rb.AddForce(Vector3.up * jumpForce*Time.deltaTime, ForceMode.Impulse);
            isJumping = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
            isGrounded = true;
     
    }
    private void OnCollisionExit(Collision collision)
    {
            isGrounded = false;
       
    }
}
