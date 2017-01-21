using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 2;

    private Vector2 movement;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        movement = Vector2.zero;

        movement.x += Input.GetAxisRaw("Horizontal");

        movement.y += Input.GetAxisRaw("Vertical");

        Debug.Log(movement);

        if (movement != Vector2.zero)
        {
            GetComponent<Animator>().SetBool("Walking", true);
            GetComponent<Animator>().SetFloat("moveX", movement.x);
            GetComponent<Animator>().SetFloat("moveY", movement.y);
        }
        else
        {
            GetComponent<Animator>().SetBool("Walking", false);
        }
        // follow this pattern

        movement *= speed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x + movement.x, transform.position.y + movement.y, transform.position.z);
    }
}
