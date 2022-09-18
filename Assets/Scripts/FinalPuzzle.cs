using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Cinemachine;
using UnityEngine.Rendering.HighDefinition;

public class FinalPuzzle : MonoBehaviour
{
    public GameObject[] greenLamps;
    public GameObject[] puzzleLamps;
    public CinemachineVirtualCamera Camera2;
    public Camera mainCamera;
    public Animator zane;
    public Volume volume;
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
        CinemachineBrain brain = mainCamera.GetComponent<CinemachineBrain>();
        brain.enabled = true;
        Camera2.Priority = 11;
        zane.SetBool("LevelComplete", true);
        volume.weight = 1;
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
