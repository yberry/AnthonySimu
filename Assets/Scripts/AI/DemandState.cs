using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemandState : IEnnemyState
{

    private readonly StatePatternEnnemy enemy;
    private int nextWayPoint;
    string answer = "Non";

    public DemandState(StatePatternEnnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        if (Yarn.Unity.DialogueRunner.runner.dialogue.currentNode == "Oui")
        {
            answer = "Oui";
        }


        if (!Yarn.Unity.DialogueRunner.runner.isDialogueRunning && answer == "Oui")
        {
            ToWaitForStuffState();
            enemy.player.GetComponent<CharacterMovement>().canMove = true;
            enemy.SetDisplayWaiting();
            answer = "Non";
        }
        else if(!Yarn.Unity.DialogueRunner.runner.isDialogueRunning && answer == "Non")
        {
            GameObject.FindGameObjectWithTag("StudentManager").GetComponent<StudentManager>().RemoveDemandStudent(enemy.gameObject);
            enemy.setNeedAnton(false);
            ToPatrolState();
            enemy.player.GetComponent<CharacterMovement>().canMove = true;
            enemy.SetDisplayNoActivity();
            answer = "Non";
        }
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToPatrolState()
    {
        enemy.currentState = enemy.patrolState;

        // SET WIFI POWER BACK HERE
    }

    public void ToChaseState()
    {

    }

    public void ToPornLoadState()
    {
        
    }

    public void ToDemandState()
    {
        Debug.Log("can't transition to demand from demand");
    }

    public void ToWaitForStuffState()
    {
        enemy.currentState = enemy.waitForStuffState;
    }

    private void Demand()
    {
        
    }
}
