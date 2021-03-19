using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public Transform target;
    public float cutsceneDuration;
    public string[] dialogues;
    public string tutorial;
    bool executued;
    // Start is called before the first frame update
    void Start()
    {
        executued = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Movement player = other.gameObject.GetComponentInChildren<Movement>();
            if (dialogues.Length != 0)
            {
                //ShowDialogue(other);
            }
            if (tutorial != null)
            {
                //ShowTutorial(other);
            }
            if (!executued && target != null)
            {
                TriggerCameraCutscene(player);
            }
        }

    }

    private void TriggerCameraCutscene(Movement player)
    {
        //executued = true;
        StartCoroutine(Cutscene(player));
    }
    IEnumerator Cutscene(Movement player)
    {
        player.PauseMovement(target);
        yield return new WaitForSeconds(cutsceneDuration);
        player.Revert();
        yield return new WaitForSeconds(cutsceneDuration);
        player.UnPauseMovement();   
    }

    private void ShowTutorial(Collider other)
    {
        throw new NotImplementedException();
    }

    private void ShowDialogue(Collider other)
    {
        throw new NotImplementedException();
    }
}
