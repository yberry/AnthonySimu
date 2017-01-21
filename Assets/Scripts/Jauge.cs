using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jauge : MonoBehaviour {

    public Image image;
    public float maxVal;
    public float startVal;

    public bool immediateUpdate;

    public bool activeIncrease;
    public float amountIncreaseBySecond = 1f;

    public bool activeDecrease;
    public float amountDecreaseBySecond = 1f;

    public bool activeStartBlinking;
    public float amountStartBlinking;
    public float freqStartBlinking;
    public Color colorStartBlinking = Color.white;

    public bool activeEndBlinking;
    public float amountEndBlinking;
    public float freqEndBlinking;
    public Color colorEndBlinking = Color.white;

    Color fillColor;
    float targetVal;
    public float TargetVal
    {
        get
        {
            return targetVal;
        }
        set
        {
            targetVal = Mathf.Clamp(value, 0f, maxVal);
            if (immediateUpdate)
            {
                CurrentVal = targetVal;
            }
        }
    }
    float currentVal;
    float CurrentVal
    {
        set
        {
            currentVal = value;
            image.fillAmount = currentVal / maxVal;
        }
    }
    public bool IsEmpty
    {
        get
        {
            return currentVal == 0f;
        }
    }
    public bool IsFull
    {
        get
        {
            return currentVal == maxVal;
        }
    }

    void Start()
    {
        image.type = Image.Type.Filled;
        fillColor = image.color;
        TargetVal = startVal;
        CurrentVal = startVal;
    }

    void Update()
    {
        IncreaseOrDecrease();

        CurrentVal = Mathf.MoveTowards(currentVal, targetVal, 1f);

        Blink();
    }

    void IncreaseOrDecrease()
    {
        if (activeIncrease)
        {
            TargetVal += amountIncreaseBySecond * Time.deltaTime;
        }
        else if (activeDecrease)
        {
            TargetVal -= amountDecreaseBySecond * Time.deltaTime;
        }
    }

    void Blink()
    {
        if (activeStartBlinking && currentVal < amountStartBlinking)
        {
            float t = (1f + Mathf.Sin(freqStartBlinking * Time.time)) * 0.5f;
            image.color = Color.Lerp(fillColor, colorStartBlinking, t);
        }
        else if (activeEndBlinking && currentVal > amountEndBlinking)
        {
            float t = (1f + Mathf.Sin(freqEndBlinking * Time.time)) * 0.5f;
            image.color = Color.Lerp(fillColor, colorEndBlinking, t);
        }
        else
        {
            image.color = fillColor;
        }
    }

    public void Add(float amount)
    {
        TargetVal += amount;
    }
}
