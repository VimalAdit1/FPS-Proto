
using UnityEngine;
using UnityEngine.Rendering;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    float mouseSensitivity = 200f;
    float rotation = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float xRotation = Input.GetAxisRaw("Mouse X")*mouseSensitivity*Time.deltaTime;
        float yRotation = Input.GetAxisRaw("Mouse Y")*mouseSensitivity*Time.deltaTime;
        player.transform.Rotate(Vector3.up, xRotation);
        rotation -= yRotation;
        rotation = Mathf.Clamp(rotation, -90, 90);
        transform.localRotation = Quaternion.Euler(rotation, 0, 0);
    }
}
