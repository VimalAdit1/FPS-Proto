
using System.Collections;
using UnityEngine;

public class Torch : MonoBehaviour
{
    bool isOn = false;
    public GameObject pointLight;
    public GameObject fire;
    public GameObject particles;
    public Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        pointLight.SetActive(false);
        fire.SetActive(false);
        particles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Q))
        {
            isOn = (isOn == true) ? false : true;
            StartCoroutine (UpdateState());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerAnimator.SetTrigger("interact");
        }
    }
 
   IEnumerator UpdateState()
    {
        playerAnimator.SetTrigger("isLighting");
        if (isOn)
        {
            pointLight.SetActive(true);
            fire.SetActive(true);
            particles.SetActive(true);
        }
        else
        {
            pointLight.SetActive(false);
            fire.SetActive(false);
            particles.SetActive(false);
        }
        yield return new WaitForSeconds(.1f);
    }
}
