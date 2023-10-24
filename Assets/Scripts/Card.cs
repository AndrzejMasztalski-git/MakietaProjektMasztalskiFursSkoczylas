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
    string card1Chosen;

    public BoardManager boardManager;


    string[] cardsList = { "Club01", "Club02", "Club03", "Club04", "Club05", "Club06", "Club07", "Club08", "Club09", "Club10", "Club11", "Club12", "Club13",
                                "Diamond01", "Diamond02", "Diamond03", "Diamond04", "Diamond05", "Diamond06", "Diamond07", "Diamond08", "Diamond09", "Diamond10", "Diamond11", "Diamond12", "Diamond13",
                                "Heart01", "Heart02", "Heart03", "Heart04", "Heart05", "Heart06", "Heart07", "Heart08", "Heart09", "Heart10", "Heart11", "Heart12", "Heart13",
                                "Spade01", "Spade02", "Spade03", "Spade04", "Spade05", "Spade06", "Spade07", "Spade08", "Spade09", "Spade10", "Spade11", "Spade12", "Spade13"};

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
