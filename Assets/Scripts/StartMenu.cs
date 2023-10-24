using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    public Dropdown menu;
    string difficulty;
    public InputField nicknameField;
    string nickname;
    
    

    // Update is called once per frame
    void Update()
    {
        nickname = nicknameField.text;

        switch(menu.value)
        {
            case 0:
                difficulty = "easy";
                break;
            case 1:
                difficulty = "medium";
                break;
            case 2:
                difficulty = "hard";
                break;
            default:
                break;
                
        }
    }

    public void StartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
}
