using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public Transform target;
    public float cutsceneDuration;
    public float messageDuration=5f;
    public int messageRepeat=3;
    public string[] dialogues;
    public string tutorial;
    bool executued;
    int count=0;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        executued = false;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Movement player = other.gameObject.GetComponentInChildren<Movement>();
            if (dialogues.Length != 0&&count<messageRepeat)
            {
                int random = UnityEngine.Random.RandomRange(0, dialogues.Length);
                ShowDialogue(dialogues[random]);
                count++;
            }
            if (tutorial != null&& !tutorial.Equals(""))
            {
                gameManager.showTutorial(tutorial);
            }
            if (!executued && target != null)
            {
                TriggerCameraCutscene(player);
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            if (tutorial != null && !tutorial.Equals(""))
            {
                gameManager.showTutorial(tutorial);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                gameManager.hideTutorial();
            
        }
    }

    private void TriggerCameraCutscene(Movement player)
    {
        executued = true;
        
    }
    IEnumerator Cutscene(Movement player)
    {
        player.PauseMovement(target);
        yield return new WaitForSeconds(cutsceneDuration);
        player.Revert();
        yield return new WaitForSeconds(cutsceneDuration);
        player.UnPauseMovement();   
    }
    IEnumerator Dialogue(string message)
    {
        gameManager.showDialog(message);
        yield return new WaitForSeconds(messageDuration);
        gameManager.hideDialog();
    }

    private void ShowTutorial(Collider other)
    {
        throw new NotImplementedException();
    }

    private void ShowDialogue(string message)
    {
        StartCoroutine(Dialogue(message));
    }
}
