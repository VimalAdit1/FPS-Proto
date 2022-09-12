
using UnityEngine;
public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    public float range = 2000f;
    Camera camera;
    Animator animator;
    GameManager gameManager;
    bool tutorial = false;
    void Start()
    {
        camera = FindObjectOfType<Camera>();
        animator = GetComponentInParent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
       if( Physics.Raycast(camera.transform.position, camera.transform.forward, out hit,range))
        {
            Item item =hit.transform.GetComponent<Item>();
            if (item != null && item.isPicked==false )
            {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        animator.SetTrigger("interact");
                        item.Interact();
                    }
                    else
                    {
                    DoorRing doorRing = hit.transform.GetComponent<DoorRing>();
                    if (doorRing != null)
                    {
                        if(doorRing.solved)
                        {
                            gameManager.showTutorial("Try Solving other rings to place");
                        }
                        else
                        {
                            gameManager.showTutorial("Press E to rotate ring");
                        }

                    }
                    else
                    {
                        gameManager.showTutorial("Press E to interact");
                        tutorial = true;
                    }
                    }
                
            }
            else
            {
                if (tutorial)
                {
                    gameManager.hideTutorial();
                    tutorial = false;
                }
            }
        }
    }
}
