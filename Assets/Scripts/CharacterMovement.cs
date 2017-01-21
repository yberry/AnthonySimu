using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 2;

    private Vector3 movement;

    private Animator animator;

    public bool hasEquipment = false;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        movement = Vector3.zero;

        movement.x += Input.GetAxisRaw("Horizontal");

        movement.z += Input.GetAxisRaw("Vertical");

        if (movement != Vector3.zero)
        {
            animator.SetBool("Walking", true);
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveZ", movement.z);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
        // follow this pattern

        movement *= speed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x + movement.x, transform.position.y, transform.position.z + movement.z);
    }
}
