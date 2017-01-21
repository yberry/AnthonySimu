using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
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

    public List<Button> buttons;
    public float successWait = 1f;
    public AudioClip clipSuccess;
    public AudioClip clipFail;

    int pornNum;
    ColorBlock baseBlock;
    AudioSource source;

    void Start()
    {
        baseBlock = buttons[0].colors;
        buttons.ForEach(b => b.gameObject.SetActive(false));
        source = GetComponent<AudioSource>();
    }

    public void Show()
    {
        pornNum = Random.Range(0, buttons.Count);

        List<string> goods = goodSites.ToList();
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i == pornNum)
            {
                string pornString = badSites[Random.Range(0, badSites.Length)];
                buttons[i].GetComponentInChildren<Text>().text = pornString;
            }
            else
            {
                int rand = Random.Range(0, goods.Count);
                buttons[i].GetComponentInChildren<Text>().text = goods[rand];
                goods.RemoveAt(rand);
            }
        }

        buttons.ForEach(b => b.gameObject.SetActive(true));
    }

    public void Click(int index)
    {
        bool found = index == pornNum;

        source.clip = found ? clipSuccess : clipFail;
        source.PlayOneShot();
        Color col = found ? Color.green : Color.red;

        ColorBlock block = buttons[index].colors;
        block.normalColor = col;
        block.highlightedColor = col;
        block.pressedColor = col;
        block.disabledColor = col;
        buttons[index].colors = block;
        buttons[index].interactable = false;

        Jauge.Flemme.Add(5f);
        Jauge.BandePassante.Add(found ? 10f : 5f);
        Jauge.Mecontentement.Add(found ? 0f : 10f);

        if (found)
        {
            StartCoroutine(Result());
        }
    }

    IEnumerator Result()
    {
        buttons.ForEach(b => b.interactable = false);

        yield return new WaitForSeconds(successWait);

        foreach (Button button in buttons)
        {
            button.colors = baseBlock;
            button.interactable = true;
            button.gameObject.SetActive(false);
        }
    }
}
