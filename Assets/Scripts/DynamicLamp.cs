using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLamp : MonoBehaviour
{
    public GameObject[] lampsGO;
    public bool value;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        foreach(GameObject lampGO in lampsGO)
        {
            lamp lamp = lampGO.GetComponentInChildren<lamp>();
            if(lamp!=null)
            {
                if(value)
                {
                    lamp.TurnOn();
                }
                else
                {
                    lamp.TurnOff();
                }
            }
        }
    }
}
