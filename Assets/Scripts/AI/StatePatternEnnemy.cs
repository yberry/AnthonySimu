using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StatePatternEnnemy : MonoBehaviour {

    public float sightRange = 20;
    public Transform[] wayPoints;
    public Transform studentComputer;

    [HideInInspector]
    public Transform chaseTarget;

    [HideInInspector]
    public IEnnemyState currentState;

    [HideInInspector]
    public ChaseState chaseState;

    [HideInInspector]
    public PornLoadState pornLoadState;

    [HideInInspector]
    public PatrolState patrolState;

    [HideInInspector]
    public NavMeshAgent navMeshAgent;

    Animator animator;
    Vector3 velocityNormalized;

    private void Awake()
    {
        chaseState = new ChaseState (this);
        patrolState = new PatrolState (this);
        pornLoadState = new PornLoadState(this);

        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Use this for initialization
    void Start ()
    {
        currentState = patrolState;
	}
	
	// Update is called once per frame
	void Update ()
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
