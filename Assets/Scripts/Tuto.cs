using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tuto : MonoBehaviour {

    public Sprite[] sprites;
    public Image image;

    int index = 0;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            index++;
            if (index < sprites.Length)
            {
                image.sprite = sprites[index];
            }
            else
            {
                SceneManager.LoadScene("MenuPrincipale");
            }
        }
    }
}
