
using System;
using System.Collections;
using UnityEngine;

public class Torch : MonoBehaviour
{
    bool isOn = false;
    public GameObject pointLight;
    public GameObject fire;
    public GameObject particles;
    public Animator playerAnimator;
    public float flickerDelay = 0.3f;
    float nextFlicker;
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
            isOn = !isOn;
            StartCoroutine (UpdateState());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerAnimator.SetTrigger("interact");
        }
        if(isOn&&Time.time>nextFlicker)
        {
            StartCoroutine(Flicker());
        }
    }

    private IEnumerator Flicker()
    {
        pointLight.GetComponent<Light>().intensity -= 3;
        yield return new WaitForSeconds(.1f);
        pointLight.GetComponent<Light>().intensity += 3;
        nextFlicker = Time.time + flickerDelay;
    }

    IEnumerator UpdateState()
    {
        playerAnimator.SetTrigger("isLighting");
        if (isOn)
        {
            pointLight.SetActive(true);
            fire.SetActive(true);
            particles.SetActive(true);
            nextFlicker = Time.time + flickerDelay;
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
