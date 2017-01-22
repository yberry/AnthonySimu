using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour {

    Transform player;
    public float distanceActivation;
    public string input = "Fire1";

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(ReleaseStress());
    }
    // Use this for initialization
    void Start()
    {
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceActivation);
    }

    IEnumerator ReleaseStress()
    {
        while (true)
        {
            if (IsNear)
            {
                Jauge.Flemme.Add(-5);
            }
            yield return new WaitForSeconds(1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
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
