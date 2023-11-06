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

    public BoardManager boardManager;

    string[] cardsList = { "K_TREFL_RZUT_P", "K_KARO_RZUT_P", "8_PIK_RZUT_P", "D_KIER_RZUT_P" };

    private void Start()
    {
        boardManager.wasPlacedOnce = true;
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
        int index1 = rnd.Next(cardsList.Length);

        card1Chosen = cardsList[index1];


        card1.GetComponent<Image>().sprite = Resources.Load<Sprite>(card1Chosen);

        card1.gameObject.SetActive(true);

        shuffleButton.gameObject.SetActive(false);
    }

    public void ShuffleButtonClicked()
    {
        ChooseCardsRandomAndSetSprite();

    }
}
