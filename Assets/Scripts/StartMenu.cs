using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;


public class StartMenu : MonoBehaviour
{
    public string difficulty;
    public InputField nicknameField;
    public string nickname;
    public GameManager gameManager;
    public GameObject gameBoard;
    public Button bombButton;
    public GameObject buttonPrefab;
    public GameObject buttonParent;
    string[] listOfDifficultyLevels = { "LOW", "MEDIUM", "HARD" };

    private void Start()
    {
        ButtonCreation();
        
    }
    void Update()
    {
        nickname = nicknameField.text;
    }

    public void StartButtonClicked()
    {
        gameManager.menu.GetComponent<Canvas>().enabled = false;
        gameManager.hud.GetComponent<Canvas>().enabled = true;
        bombButton.GetComponent<Button>().enabled = true;
        gameBoard.SetActive(true);
        gameManager.difficultySet = true;
        nickname = nicknameField.text;
    }



    void ButtonCreation()
    {
        int i = 0;
        int x = 50;
        foreach(string item in listOfDifficultyLevels)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonParent.transform);
            newButton.GetComponent<Button>().image.sprite = Resources.Load<Sprite>(item);
            newButton.transform.position = new Vector3(x + 250, 230, 0);
            x += 250;
            newButton.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(item));
        }
    }

    void ButtonClicked(string diff)
    {
        difficulty = diff;
    }
}
