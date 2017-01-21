using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListWebsites : MonoBehaviour {

    static readonly string[] goodSites = new string[]
    {
        "Face De Livre",
        "Twotter",
        "LikeADaim",
        "Gamasutra",
        "jeuxvideal",
        "irreelengin",
        "unite",
        "globalgamejam"
    };

    static readonly string[] badSites = new string[]
    {
        "Brozzers",
        "YaKaMaTé",
        "xYoshi",
        "LubriSoft",
        "Ankama-sutra",
        "VRPorn"
    };

    const int numSites = 6;

    Button[] buttons;

    void Start()
    {
        int badNum = Random.Range(0, numSites);

        buttons = new Button[numSites];
        for (int i = 0; i < numSites; i++)
        {

        }
    }
}
