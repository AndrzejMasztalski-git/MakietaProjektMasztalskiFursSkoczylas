using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int cardsCounter = 0;
    public Button card1;
    public Button shuffleButton;
    public string card1Chosen;

    public string Symbol { get; set; }
    public string Piktogram { get; set; }
    public GameObject Model3D { get; set; }

    public BoardManager boardManager;

    public GameObject hospitalPrefab;
    public GameObject schoolPrefab;
    public GameObject marketPrefab;
    public GameObject fire_StationPrefab;

    private List<string> cardsList = new List<string>
    {
        "J_TREFL_RZUT_P",
        "K_KARO_RZUT_P",
        "8_PIK_RZUT_P",
        "D_KIER_RZUT_P"
    };

    private void Start()
    {
        shuffleButton.gameObject.SetActive(false);
        cardsCounter = boardManager.rows * boardManager.columns;
        ChooseCardsRandomAndSetSprite();
    }

    public void Card1Clicked()
    {
        card1.gameObject.SetActive(false);

        cardsCounter--;
        
        boardManager.wasPlacedOnce = false;
    }


    public void ChooseCardsRandomAndSetSprite()
    {
        System.Random rnd = new System.Random();
        int index = rnd.Next(cardsList.Count);

        card1Chosen = cardsList[index];
        Symbol = card1Chosen.Split('_')[0];

        card1.gameObject.SetActive(true);

        // £adowanie sprite'a o nazwie card1Chosen z Resources
        Sprite cardSprite = Resources.Load<Sprite>(card1Chosen);

        if (cardSprite != null)
        {
            // Jeœli sprite zosta³ za³adowany poprawnie, ustaw go w komponencie Image na card1
            card1.GetComponent<Image>().sprite = cardSprite;
        }
        else
        {
            Debug.LogWarning("Nie znaleziono sprite'a: " + card1Chosen);
        }

        shuffleButton.gameObject.SetActive(false);

        boardManager.wasPlacedOnce = true;
    }

    public void ShuffleButtonClicked()
    {
        ChooseCardsRandomAndSetSprite();
    }
}
