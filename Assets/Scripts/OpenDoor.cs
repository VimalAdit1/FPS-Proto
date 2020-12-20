using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    public KeyCode key;
    bool isOpened;
    bool isNear;
    // Start is called before the first frame update
    void Start()
    {
        isOpened = false; 
        isNear = false;  
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isOpened)
        {
            isNear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isNear = false;
    }
   
    private void Update()
    {
        if(isNear&&!isOpened)
        {
            checkInput();
        }
    }

    private void checkInput()
    {
        if(!isOpened)
        {
            if(Input.GetKeyDown(key))
            {
                Open();
            }
        }
    }

    private void Open()
    {
        Animator doorAnimator = door.GetComponent<Animator>();
        doorAnimator.SetTrigger("Open");
        isOpened = true;
    }
}
