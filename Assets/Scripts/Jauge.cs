using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jauge : MonoBehaviour {

    public Image image;
    public float maxVal;

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
        currentVal = maxVal;
    }

    void Update()
    {
        CurrentVal = Mathf.MoveTowards(currentVal, targetVal, 1f);

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

    public void Add(int amount)
    {
        TargetVal += amount;
    }
}
