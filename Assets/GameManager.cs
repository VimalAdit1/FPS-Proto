﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI dialog;
    public TextMeshProUGUI tutorial;

    public GameObject dialogBox;
    public GameObject tutorialBox;

    // Start is called before the first frame update
    void Start()
    {
        hideDialog();
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

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void PlaayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
