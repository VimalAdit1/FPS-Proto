using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI dialog;
    public TextMeshProUGUI tutorial;

    public GameObject dialogBox;
    public GameObject tutorialBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showTutorial(string message)
    {
        tutorialBox.SetActive(true);
        tutorial.text = message;
    }
    public void hideTutorial()
    {
        tutorialBox.SetActive(false);
    }
    public void hideDialog()
    {
        dialogBox.SetActive(false);
    }

    public void showDialog(string message)
    {
        dialogBox.SetActive(true);
        dialog.text = message;
    }
}
