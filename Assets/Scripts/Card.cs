using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] int cardsCounter = 0;
    public Button card1;
    public Button card2;
    public Button card3;
    public Button card4;
    public Button shuffleButton;
    string card1Chosen;
    string card2Chosen;
    string card3Chosen;
    string card4Chosen;


    string[] cardsList = { "Club01", "Club02", "Club03", "Club04", "Club05", "Club06", "Club07", "Club08", "Club09", "Club10", "Club11", "Club12", "Club13",
                                "Diamond01", "Diamond02", "Diamond03", "Diamond04", "Diamond05", "Diamond06", "Diamond07", "Diamond08", "Diamond09", "Diamond10", "Diamond11", "Diamond12", "Diamond13",
                                "Heart01", "Heart02", "Heart03", "Heart04", "Heart05", "Heart06", "Heart07", "Heart08", "Heart09", "Heart10", "Heart11", "Heart12", "Heart13",
                                "Spade01", "Spade02", "Spade03", "Spade04", "Spade05", "Spade06", "Spade07", "Spade08", "Spade09", "Spade10", "Spade11", "Spade12", "Spade13"};

    private void Start()
    {
        shuffleButton.gameObject.SetActive(false);
        cardsCounter = 4;
        ChooseCardsRandomAndSetSprite();

    }
    private void Update()
    {
        if(cardsCounter == 0)
        {
            shuffleButton.gameObject.SetActive(true);
        }
    }
    public void Card1Clicked()
    {
        card1.gameObject.SetActive(false);
        cardsCounter--;
    }

    public void Card2Clicked()
    {
        card2.gameObject.SetActive(false);
        cardsCounter--;
    }

    public void Card3Clicked()
    {
        card3.gameObject.SetActive(false);
        cardsCounter--;
    }

    public void Card4Clicked()
    {
        card4.gameObject.SetActive(false);
        cardsCounter--;
    }


    public void ChooseCardsRandomAndSetSprite()
    {
        System.Random rnd = new System.Random();
        int index1 = rnd.Next(cardsList.Length);
        int index2 = rnd.Next(cardsList.Length);
        int index3 = rnd.Next(cardsList.Length);
        int index4 = rnd.Next(cardsList.Length);

        card1Chosen = cardsList[index1];
        card2Chosen = cardsList[index2];
        card3Chosen = cardsList[index3];
        card4Chosen = cardsList[index4];


        card1.GetComponent<Image>().sprite = Resources.Load<Sprite>(card1Chosen);
        card2.GetComponent<Image>().sprite = Resources.Load<Sprite>(card2Chosen);
        card3.GetComponent<Image>().sprite = Resources.Load<Sprite>(card3Chosen);
        card4.GetComponent<Image>().sprite = Resources.Load<Sprite>(card4Chosen);

        card1.gameObject.SetActive(true);
        card2.gameObject.SetActive(true);
        card3.gameObject.SetActive(true);
        card4.gameObject.SetActive(true);

        shuffleButton.gameObject.SetActive(false);
    }

    public void ShuffleButtonClicked()
    {
        ChooseCardsRandomAndSetSprite();
        cardsCounter = 4;
    }
}
