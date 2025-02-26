﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 1.8f;
    public float strafeSpeed = 1.8f;
    public float jumpForce = 700f;
    float sprintMultiplier = 1f;
    public bool isSprinting = false;
    bool isJumping = false;
    float move;
    float strafe;
    public Rigidbody rb;
    public Animator animator;
    public bool isGrounded;
    public bool isPaused;
    public MoveCamera camera;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
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
            if (Input.GetButton("Jump") && isGrounded)
            {
                isJumping = true;
            }
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

    public bool PauseMovement(Transform target)
    {
        /*Rotate Player
        Vector3 direction = target.position - transform.position;
        Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
        this.transform.localRotation=Quaternion.Euler(new Vector3(transform.localRotation.x,toRotation.eulerAngles.y,transform.localRotation.z);
        /Rotate Camera*/

        //Rotate Camera back
        isPaused = true;
        strafe = 0;
        move = 0;
        camera.isLocked = isPaused;
        if (target != null)
        {
            camera.LookAt(target);
        }
        return isPaused;
    }
    public void Revert()
    {
        camera.RemoveTarget();
    }

    public void UnPauseMovement()
    {
        isPaused = false;
        camera.isLocked = isPaused;
        camera.revert = isPaused;
    }
}

