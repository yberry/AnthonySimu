﻿using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn;

public class Dialog : Yarn.Unity.DialogueUIBehaviour {

    public GameObject dialogueContainer;
    public Image perso;
    public Animator animator;
    public Text nameText;
    public Text lineText;
    public GameObject continuePrompt;

    [Serializable]
    public struct NameSprite
    {
        public string name;
        public string anim;
    }
    public NameSprite[] nameSprites;

    OptionChooser setSelectedOption;
    Dictionary<string, string> dico;

    public float textSpeed = 0.025f;
    public List<Button> optionButtons;
    public RectTransform gameControlsContainer;

    void Awake()
    {
        if (dialogueContainer != null)
        {
            dialogueContainer.SetActive(false);
        }

        lineText.gameObject.SetActive(false);

        optionButtons.ForEach(b => b.gameObject.SetActive(false));

        if (continuePrompt != null)
        {
            continuePrompt.SetActive(false);
        }

        dico = nameSprites.ToDictionary(ns => ns.name, ns => ns.anim);
    }

    public override IEnumerator RunLine(Line line)
    {
        lineText.gameObject.SetActive(true);

        List<string> fullLine = line.text.Split(':').ToList();
        nameText.text = fullLine[0];
        if (dico.ContainsKey(fullLine[0]))
        {
            animator.SetTrigger(fullLine[0]);
        }
        perso.SetNativeSize();

        fullLine.RemoveAt(0);
        string text = string.Join(":", fullLine.ToArray());

        if (textSpeed > 0f)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in text)
            {
                stringBuilder.Append(c);
                lineText.text = stringBuilder.ToString();
                yield return new WaitForSeconds(textSpeed);
            }
        }
        else
        {
            lineText.text = text;
        }

        if (continuePrompt != null)
        {
            continuePrompt.SetActive(true);
        }

        while (!Input.anyKeyDown)
        {
            yield return null;
        }

        //lineText.gameObject.SetActive(false);

        if (continuePrompt != null)
        {
            continuePrompt.SetActive(false);
        }
    }

    public override IEnumerator RunOptions(Options optionsCollection, OptionChooser optionChooser)
    {
        if (optionsCollection.options.Count > optionButtons.Count)
        {
            Debug.LogWarning("There are more options to present than there are buttons to present them in. This will cause problems.");
        }

        for (int i = 0; i < optionsCollection.options.Count; i++)
        {
            Button optionButton = optionButtons[i];
            optionButton.gameObject.SetActive(true);
            optionButton.GetComponentInChildren<Text>().text = optionsCollection.options[i];
        }

        setSelectedOption = optionChooser;

        while (setSelectedOption != null)
        {
            yield return null;
        }

        optionButtons.ForEach(b => b.gameObject.SetActive(false));
    }

    public void SetOption(int selectedOption)
    {
        if (selectedOption == 1)
        {
            Jauge.Mecontentement.Add(15f);
        }

        setSelectedOption(selectedOption);

        setSelectedOption = null;
    }

    public override IEnumerator RunCommand(Command command)
    {
        throw new NotImplementedException();
    }

    public override IEnumerator DialogueStarted()
    {
        if (dialogueContainer != null)
        {
            dialogueContainer.SetActive(true);
        }

        if (gameControlsContainer != null)
        {
            gameControlsContainer.gameObject.SetActive(false);
        }

        yield break;
    }

    public override IEnumerator DialogueComplete()
    {
        if (dialogueContainer != null)
        {
            dialogueContainer.SetActive(false);
        }

        if (gameControlsContainer != null)
        {
            gameControlsContainer.gameObject.SetActive(true);
        }

        yield break;
    }
}
