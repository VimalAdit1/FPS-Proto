using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    Movement movement;
    public bool isEnabled;
    // Start is called before the first frame update
    void Start()
    {
       movement = transform.parent.GetComponent<Movement>();
        if(movement!=null)
        {
            isEnabled = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isEnabled)
        {
            movement.isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (isEnabled)
        {
            movement.isGrounded = false;
        }
    }
}
