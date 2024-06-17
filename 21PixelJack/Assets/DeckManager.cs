using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    //Sprites
    [SerializeField] private Sprite[] frontSprites = new Sprite[52];

    private Sprite[] backSprites = new Sprite[52];
    [SerializeField] private Sprite backB;
    [SerializeField] private Sprite backR;

    //CardPrefab
    public GameObject cardPref;


    //DeckCards
    public GameObject[] deck = new GameObject[52];
    public GameObject pileObject;
    public GameObject deckObject;

    // Start is called before the first frame update
    void Start()
    {
        //Fill and Shuffle back sprites
        fillShuffleBack();


        //Fill Cards
        int indexReal = 0;
        for (int j = 0; j < 4; j++)
        {
            for (int i = 1; i < 11; i++)
            {

                GameObject newcard = Instantiate(cardPref, deckObject.transform, false);

                Card objScrpt = newcard.GetComponent<Card>();

                objScrpt.Value = i;

                objScrpt.FrontSpr = frontSprites[indexReal];
                objScrpt.BackSpr = backSprites[indexReal];



                deck[indexReal] = newcard;

                indexReal++;
            }
            for (int i = 0; i < 3; i++)
            {
                GameObject newcard = Instantiate(cardPref, deckObject.transform, false);

                Card objScrpt = newcard.GetComponent<Card>();

                objScrpt.Value = 10;

                objScrpt.FrontSpr = frontSprites[indexReal];
                objScrpt.BackSpr = backSprites[indexReal];



                deck[indexReal] = newcard;

                indexReal++;
            }
        }
        
    
    }

    public void fillShuffleBack()
    {
        for (int i = 0; i < 52; i++)
        {
            if (i < 26)
            {
                backSprites[i] = backB;
            }
            else
            {
                backSprites[i] = backR;
            }
        }
        System.Random rng = new System.Random();
        int n = 52;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Sprite value = backSprites[k];
            backSprites[k] = backSprites[n];
            backSprites[n] = value;
        }

    }



}
