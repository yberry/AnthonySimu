﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Jauge : MonoBehaviour {

    public enum Type
    {
        None,
        Flemme,
        BandePassante,
        Mecontentement
    }

    public Type type;

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

    public AudioClip[] increaseClips;
    public AudioClip[] decreaseClips;
    public AudioClip alerteClip;

    bool alerte = false;
    AudioSource source;
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
    public float CurrentVal
    {
        get
        {
            return currentVal;
        }
        private set
        {
            currentVal = value;
            image.fillAmount = currentVal / maxVal;
            CheckGameOver();
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
    bool StartCritical
    {
        get
        {
            return activeStartBlinking && currentVal < amountStartBlinking;
        }
    }
    bool EndCritical
    {
        get
        {
            return activeEndBlinking && currentVal > amountEndBlinking;
        }
    }
    public bool IsCritical
    {
        get
        {
            return StartCritical || EndCritical;
        }
    }

    static Jauge flemme;
    public static Jauge Flemme
    {
        get
        {
            return flemme;
        }
    }
    static Jauge bandePassante;
    public static Jauge BandePassante
    {
        get
        {
            return bandePassante;
        }
    }
    static Jauge mecontentement;
    public static Jauge Mecontentement
    {
        get
        {
            return mecontentement;
        }
    }

    void Start()
    {
        switch (type)
        {
            case Type.Flemme:
                flemme = this;
                break;

            case Type.BandePassante:
                bandePassante = this;
                break;

            case Type.Mecontentement:
                mecontentement = this;
                break;
        }

        image.type = Image.Type.Filled;
        fillColor = image.color;
        TargetVal = startVal;
        currentVal = startVal;
        image.fillAmount = currentVal / maxVal;
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
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
        if (StartCritical)
        {
            float t = (1f + Mathf.Sin(freqStartBlinking * Time.time)) * 0.5f;
            image.color = Color.Lerp(fillColor, colorStartBlinking, t);
        }
        else if (EndCritical)
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
        if (amount >= 15f && increaseClips.Length > 2)
        {
            source.PlayOneShot(increaseClips[2]);
        }
        else if (amount >= 10f && increaseClips.Length > 1)
        {
            source.PlayOneShot(increaseClips[1]);
        }
        else if (amount >= 5f && increaseClips.Length > 0)
        {
            source.PlayOneShot(increaseClips[0]);
        }
        else if (amount <= -15f && decreaseClips.Length > 2)
        {
            source.PlayOneShot(decreaseClips[2]);
        }
        else if (amount <= -10f && decreaseClips.Length > 1)
        {
            source.PlayOneShot(decreaseClips[1]);
        }
        else if (amount <= -5f && decreaseClips.Length > 0)
        {
            source.PlayOneShot(decreaseClips[0]);
        }

        if (IsCritical && !alerte)
        {
            alerte = true;
            source.PlayOneShot(alerteClip);
        }
        else if (!IsCritical && alerte)
        {
            alerte = false;
        }
    }

    void CheckGameOver()
    {
        if (flemme.IsFull || bandePassante.IsEmpty || mecontentement.IsFull)
        {
            if (flemme.IsFull)
            {
                PlayerPrefs.SetString("Over", "Anton1");
            }
            else if (bandePassante.IsEmpty)
            {
                PlayerPrefs.SetString("Over", "Anton2");
            }
            else if (mecontentement.IsFull)
            {
                PlayerPrefs.SetString("Over", "Anton0");
            }
            SceneManager.LoadScene("Over");
        }
    }
}
