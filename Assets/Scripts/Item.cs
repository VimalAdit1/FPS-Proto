
using UnityEngine;
using UnityEngine.XR;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPicked = false;
    public Transform offset;
    Transform originalOffset;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalOffset = offset;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
    }
    public void Pickup()
    {
        isPicked = true;
        this.transform.position = originalOffset.position;
        this.transform.rotation = originalOffset.rotation;
        rb.isKinematic = true;
    }
    public void Drop()
    {
        if(isPicked==true)
        {
            isPicked = false;
            rb.isKinematic = false;
            this.transform.parent = null;
        }
    }
}
