using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamp : Item
{
    bool isOn = false;
    bool forced = false;
    public GameObject pointLight;
    public bool burnOnInstance=false;
    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        isOn = burnOnInstance;
        pointLight.SetActive(isOn);
        particles.SetActive(isOn);
        
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
    public void TurnOn()
    {
        Debug.Log("turn on!!!");
        if (!isOn&&!forced)
        {
            isOn = true;
            StartCoroutine(UpdateState());
        }
    }public void TurnOff()
    {
        if (isOn&&!forced)
        {
            isOn = false;
            forced = true;
            StartCoroutine(UpdateState());
        }
    }
    IEnumerator UpdateState()
    {
            pointLight.SetActive(isOn);
            particles.SetActive(isOn);
        
        yield return new WaitForSeconds(.1f);
    }
}
