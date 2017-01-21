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
    public PatrolState patrolState;

    [HideInInspector]
    public PornLoadState pornLoadState;

    [HideInInspector]
    public DemandState demandState;

    [HideInInspector]
    public NavMeshAgent navMeshAgent;

    Animator animator;
    Vector3 velocityNormalized;

    bool needAnton = false;
    SpriteRenderer stateIcon;// ca et en dessous c'est degueu
    Animator stateAnim;

    private void Awake()
    {
        chaseState = new ChaseState (this);
        patrolState = new PatrolState (this);
        pornLoadState = new PornLoadState(this);
        demandState = new DemandState(this);

        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        stateIcon = transform.FindChild("StateIcon").GetComponent<SpriteRenderer>();
        stateAnim = transform.FindChild("StateIcon").GetComponent<Animator>();
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

    public void setNeedAnton(bool need)
    {
        needAnton = need;
        stateIcon.enabled = true;
    }

    public void SetDisplayPornLoad(bool isDiplay) //used in patrol state!!!!
    {
        if(isDiplay)
        {
            stateAnim.enabled = true;
            stateIcon.enabled = true;
        }
        else
        {
            stateAnim.enabled = false;
            stateIcon.enabled = false;
        }
    }

    public bool GetNeedAnton()
    {
        return needAnton;
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
}
