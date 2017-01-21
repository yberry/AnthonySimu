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
    float currentVal;
    public float CurrentVal
    {
        get
        {
            return currentVal;
        }
        set
        {
            currentVal = Mathf.Clamp(value, 0f, maxVal);
            image.fillAmount = currentVal / maxVal;
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
        CurrentVal -= 3f * Time.deltaTime;

        if (activeStartBlinking && currentVal < amountStartBlinking)
        {
            float t = (1f + Mathf.Sin(freqStartBlinking * Time.time)) / 2f;
            image.color = Color.Lerp(fillColor, colorStartBlinking, t);
        }
        else if (activeEndBlinking && currentVal > amountEndBlinking)
        {
            float t = (1f + Mathf.Sin(freqEndBlinking * Time.time)) / 2f;
            image.color = Color.Lerp(fillColor, colorEndBlinking, t);
        }
        else
        {
            image.color = fillColor;
        }
    }
}
