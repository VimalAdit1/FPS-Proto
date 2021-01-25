using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamp : Item
{
    bool isOn = false;
    public GameObject pointLight;
    public bool burnOnInstance=false;
    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        pointLight.SetActive(false);
        particles.SetActive(false);
        if(burnOnInstance)
        {
            Interact();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact()
    {
        isOn = (isOn == true) ? false : true;
        StartCoroutine(UpdateState());
    }
    IEnumerator UpdateState()
    {
        
        if (isOn)
        {
            pointLight.SetActive(true);
            particles.SetActive(true);
        }
        else
        {
            pointLight.SetActive(false);
            particles.SetActive(false);
        }
        yield return new WaitForSeconds(.1f);
    }
}
