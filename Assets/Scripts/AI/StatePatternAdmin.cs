using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StatePatternAdmin : MonoBehaviour
{

    public AudioSource epicMusic;
    public float sightRange = 20;
    public Transform[] wayPoints;

    [HideInInspector]
    public IAdminState currentState;

    [HideInInspector]
    public WanderState wanderState;

    [HideInInspector]
    public TalkingState talkingState;

    [HideInInspector]
    public NavMeshAgent navMeshAgent;

    Animator animator;
    Vector3 velocityNormalized;

    [HideInInspector]
    public Transform player;

    private void Awake()
    {
        wanderState = new WanderState(this);
        talkingState = new TalkingState(this);

        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Use this for initialization
    void Start()
    {
        currentState = wanderState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();

        velocityNormalized = navMeshAgent.velocity.normalized;
        if (navMeshAgent.velocity.sqrMagnitude > 1)
        {
            animator.SetBool("Walking", true);
            animator.SetFloat("moveX", velocityNormalized.x);
            animator.SetFloat("moveZ", velocityNormalized.z);
        }
        else
        {
            animator.SetBool("Walking", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
}
