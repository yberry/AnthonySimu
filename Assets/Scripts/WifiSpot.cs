using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource), typeof(SpriteRenderer))]
public class WifiSpot : MonoBehaviour {

    public Jauge jauge;
    [Header("Color blinking")]
    public Color blink1 = Color.red;
    public Color blink2 = Color.white;
    public float freqBlinking = 1f;
    [Header("Reparation")]
    public float distanceActivation = 5f;
    public string input = "Fire1";
    public float reparationTime = 5f;

    AudioSource source;
    SpriteRenderer sprite;
    Transform player;
    bool repaired = false;
    bool isRepairing = false;

    bool IsNear
    {
        get
        {
            Vector3 diff = transform.position - player.position;
            diff.y = 0f;
            return diff.magnitude <= distanceActivation;
        }
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        jauge.gameObject.SetActive(false);
    }

    void Update()
    {
        UpdateColor();

        if (repaired)
        {
            return;
        }

        if (!isRepairing)
        {
            ActiveReparation();
        }
        else
        {
            Repair();
        }
    }

    void UpdateColor()
    {
        if (repaired)
        {
            sprite.color = Color.white;
        }
        else if (blink1 == blink2)
        {
            sprite.color = blink1;
        }
        else
        {
            float t = (1f + Mathf.Sin(freqBlinking * Time.time)) * 0.5f;
            sprite.color = Color.Lerp(blink1, blink2, t);
        }
    }

    void ActiveReparation()
    {
        if (Input.GetAxis(input) > 0f && IsNear)
        {
            isRepairing = true;
            jauge.gameObject.SetActive(true);
            source.Play();
            //Block player
        }
    }

    void Repair()
    {
        if (Input.GetAxis(input) > 0f)
        {
            jauge.Add(jauge.maxVal * Time.deltaTime / reparationTime);
            if (jauge.IsFull)
            {
                repaired = true;
                Jauge.Flemme.Add(5f);
                Jauge.BandePassante.Add(15f);
                Jauge.Mecontentement.Add(-10f);
                Stop();
            }
        }
        else
        {
            //Release player
            jauge.TargetVal = 0f;
            Stop();
        }
    }

    void Stop()
    {
        jauge.gameObject.SetActive(false);
        source.Stop();
        isRepairing = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceActivation);
    }
}
