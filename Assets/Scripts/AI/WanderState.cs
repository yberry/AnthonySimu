using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : IAdminState
{

    private readonly StatePatternAdmin admin;
    private int nextWayPoint;

    public WanderState(StatePatternAdmin statePatternAdmin)
    {
        admin = statePatternAdmin;
    }

    public void UpdateState()
    {
        Patrol();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !Yarn.Unity.DialogueRunner.runner.isDialogueRunning)
        {
            admin.navMeshAgent.destination = admin.player.position;
            admin.GetComponent<PersoDialog>().StartDialogue();
            admin.player.GetComponent<CharacterMovement>().canMove = false;
            ToTalkingState();
        }
    }

    public void ToWanderState()
    {
        Debug.Log("can't transition to wander from wander");
    }

    public void ToTalkingState()
    {
        admin.currentState = admin.talkingState;
    }

    void Patrol()
    {
        admin.navMeshAgent.destination = admin.wayPoints[nextWayPoint].position;
        admin.navMeshAgent.Resume();

        if (admin.navMeshAgent.remainingDistance <= admin.navMeshAgent.stoppingDistance && !admin.navMeshAgent.pathPending)
        {
            nextWayPoint = (nextWayPoint + 1) % admin.wayPoints.Length;
        }
    }
}
