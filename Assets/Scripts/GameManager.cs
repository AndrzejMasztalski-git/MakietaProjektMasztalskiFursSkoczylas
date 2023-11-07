using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameBoard;
    public StartMenu menuStart;
    public Text nickname;
    public Text difficulty;
    public Canvas menu;
    public Canvas hud;
    void Start()
    {
        menu.GetComponent<Canvas>().enabled = true;
        hud.GetComponent<Canvas>().enabled = false;
        gameBoard.SetActive(false);
    }

    private void Update()
    {
        nickname.text = menuStart.nickname;
        switch(menuStart.difficulty)
        {
            case "LOW": difficulty.text = "LOW";
                    break;
            case "MEDIUM":
                difficulty.text = "MEDIUM";
                    break;
            case "HARD":
                difficulty.text = "HARD";
                    break;
        }
            
    }

}
