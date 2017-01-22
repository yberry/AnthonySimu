using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingState : IAdminState
{

    private readonly StatePatternAdmin admin;
    private int nextWayPoint;

    public TalkingState(StatePatternAdmin statePatternAdmin)
    {
        admin = statePatternAdmin;
    }

    public void UpdateState()
    {
        if (!Yarn.Unity.DialogueRunner.runner.isDialogueRunning )
        {
            admin.epicMusic.volume = 0.2f;
            admin.GetComponent<AudioSource>().Stop();
            admin.player.GetComponent<CharacterMovement>().canMove = true;
            ToWanderState();
        }
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToWanderState()
    {
        admin.currentState = admin.wanderState;
    }

    public void ToTalkingState()
    {
        Debug.Log("can't transition to talking from talking");
    }
}

