using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameBoard;
    public Button bombButton;
    public StartMenu menuStart;
    public Text nickname;
    public Text difficulty;
    public Canvas menu;
    public Canvas hud;
    public Text bombsLeft;
    public int bombCounter = 0;
    public bool difficultySet = false;
    void Start()
    {
        bombButton.GetComponent<Button>().enabled = false;
        menu.GetComponent<Canvas>().enabled = true;
        hud.GetComponent<Canvas>().enabled = false;
        gameBoard.SetActive(false);
    }

    private void Update()
    {
        nickname.text = menuStart.nickname;
        if(difficultySet)
        {
            switch (menuStart.difficulty)
            {
                case "LOW":
                    difficulty.text = "LOW";
                    bombCounter = 2;
                    bombsLeft.text = $"{bombCounter}";
                    break;
                case "MEDIUM":
                    difficulty.text = "MEDIUM";
                    bombCounter = 4;
                    bombsLeft.text = $"{bombCounter}";
                    break;
                case "HARD":
                    difficulty.text = "HARD";
                    bombCounter = 6;
                    bombsLeft.text = $"{bombCounter}";
                    break;
            }
            difficultySet = false;
        }
        
            
    }

}
