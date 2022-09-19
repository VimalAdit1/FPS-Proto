using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zane : MonoBehaviour
{
    // Start is called before the first frame update

    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DialogEvent()
    {
        gameManager.showDialog("Suzzane....?");
    }

    public void GameOver()
    {
        gameManager.GameOver();
    }
}
