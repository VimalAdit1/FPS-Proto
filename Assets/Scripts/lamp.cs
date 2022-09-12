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

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        isOn = burnOnInstance;
        pointLight.SetActive(isOn);
        particles.SetActive(isOn);
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact()
    {
        isOn = !isOn;
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
    public bool isTurnedOn()
    {
        return isOn;
    }
}
