﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    void Start()
    {
        DialogueRunner.runner.StartDialogue("Anton0"); //PlayerPrefs.GetString("Over"));
    }

    void Update()
    {
        if (!DialogueRunner.runner.isDialogueRunning)
        {
            SceneManager.LoadScene("MenuPrincipale");
        }
    }
}
