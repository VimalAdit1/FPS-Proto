
using UnityEngine;
using UnityEngine.Rendering;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    float mouseSensitivity = 200f;
    float rotation = 0;
    public bool isLocked;
    public GameObject crossHair;
    float xRotation;
    float yRotation;
    Transform target;
    Vector3 start;
    public bool revert;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isLocked = false;
        revert = false;
    }

    // Update is called once per frame
    void Update()
    {
        xRotation = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        yRotation = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if(target!=null)
        {
            Vector3 direction = target.position - transform.position;
            Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 2f*Time.deltaTime);
        }
        else if (revert)
        {
            Vector3 direction = transform.position-start;
            Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 3f * Time.deltaTime);
        }
        else if(!isLocked)
        {
            
                player.transform.Rotate(Vector3.up, xRotation);
                rotation -= yRotation;
                rotation = Mathf.Clamp(rotation, -90, 90);
                transform.localRotation = Quaternion.Euler(rotation, 0, 0);
            
        }

    }

    public void LookAt(Transform target)
    {
        start = this.transform.position;
        this.target = target;
    }
    public void RemoveTarget()
    {
        revert = true;
        this.target = null;
    }
}
