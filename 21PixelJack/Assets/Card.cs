using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //Components
    private SpriteRenderer spr;
    private Transform transf;

    //Components
    [SerializeField] private int value;
    [SerializeField] private Sprite backSpr;
    [SerializeField] private Sprite frontSpr;


    //Getters & Setters
    public int Value { get => value; set => this.value = value; }
    public Sprite BackSpr { get => backSpr; set => backSpr = value; }
    public Sprite FrontSpr { get => frontSpr; set => frontSpr = value; }



    //Methods
    void Start()
    {
        //Get components from the object
        spr = GetComponent<SpriteRenderer>();
        transf = GetComponent<Transform>();
        spr.sprite=BackSpr;
    }

    //Refresh spr

    public void applyFrontSpr()
    {
        spr.sprite = FrontSpr;
    }

    public void applyBackSpr()
    {
        spr.sprite = BackSpr;
    }





    //Flip card effect

    public void flipCard(bool front)
    {
        StartCoroutine(flipcardCoroutine(front));
    }

    public IEnumerator flipcardCoroutine(bool front)
    {
        yield return StartCoroutine(flipNDegrees(90));

        if (front)
        {
            applyFrontSpr();
        }
        else
        {
            applyBackSpr();
        }

        yield return StartCoroutine(flipNDegrees(-90));
    }


    private IEnumerator flipNDegrees(int objective)
    {
        Quaternion startRotation = transf.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, objective, 0);
        float timeElapsed = 0;
        float duration = 0.25f;    

        while (timeElapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
    }
}

