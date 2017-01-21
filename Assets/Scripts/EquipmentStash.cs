﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentStash : MonoBehaviour
{

    Transform player;
    public float distanceActivation;
    public string input = "Fire1";

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(input) > 0f && IsNear)
        {
            player.GetComponent<CharacterMovement>().hasEquipment = true;
        }
    }

    bool IsNear
    {
        get
        {
            Vector3 diff = transform.position - player.position;
            diff.y = 0f;
            return diff.magnitude <= distanceActivation;
        }
    }
}
