using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class FinalPuzzle : MonoBehaviour
{
    public GameObject[] greenLamps;
    public GameObject[] puzzleLamps;
    bool isComplete;
    
    void Start()
    {
        isComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isComplete)
        {
            bool isNotTurnedOn = false;
            foreach (GameObject torch in puzzleLamps)
            {
                lamp l = torch.GetComponentInChildren<lamp>();
                if (!l.isTurnedOn())
                {
                    isNotTurnedOn = true;
                    break;
                }
            }
            if(!isNotTurnedOn)
            {
                isComplete = true;
                GameEnd();
            }
        }
    }

    void GameEnd()
    {
        TurnRed();
    }
    void TurnRed()
    {
        foreach (GameObject torch in greenLamps)
        {
            //lamp l = lamp.GetComponent<lamp>();
            //l.TurnOff();
            HDAdditionalLightData light = torch.GetComponentInChildren<HDAdditionalLightData>();
            light.color = Color.red;
            Debug.Log(light.color);
        }
    }
}
