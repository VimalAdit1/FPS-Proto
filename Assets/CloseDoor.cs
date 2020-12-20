using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    private bool isClosed;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        isClosed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isClosed)
        {
            Close();
        }
    }

    private void Close()
    {
        Animator doorAnimator = door.GetComponent<Animator>();
        doorAnimator.SetTrigger("Close");
        isClosed = true;
    }
}
