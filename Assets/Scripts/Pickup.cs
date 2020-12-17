
using UnityEngine;
public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    public float range = 2000f;
    Camera camera;
    Animator animator;
    void Start()
    {
        camera = FindObjectOfType<Camera>();
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
       if( Physics.Raycast(camera.transform.position, camera.transform.forward, out hit,range))
        {
            Item item =hit.transform.GetComponent<Item>();
            if (item != null)
                Debug.Log("pickupp!!"+item.isPicked);
            if (item != null && item.isPicked==false && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("picking up!!");
                item.transform.parent = this.transform;
                animator.SetTrigger("isPicking");
                item.Pickup();
                
            }
        }
    }
}
