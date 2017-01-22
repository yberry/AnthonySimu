using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntonPC : MonoBehaviour
{

    Transform player;
    StudentManager studentManager;
    public float distanceActivation;
    public string input = "Fire1";

    public GameObject websites;

    bool websitesOn = false;

    void Awake()
    {
        studentManager = GameObject.FindGameObjectWithTag("StudentManager").GetComponent<StudentManager>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(input) > 0f && IsNear && studentManager.isPornLoading && !websitesOn)
        {
            GetComponent<AudioSource>().Play();
            websitesOn = true;
            websites.GetComponent<ListWebsites>().Show();
            player.GetComponent<CharacterMovement>().canMove = false;
        }
    }

    public void WinSiteChoice()
    {
        studentManager.StopPornStudents();
        websitesOn = false;
        player.GetComponent<CharacterMovement>().canMove = true;
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
