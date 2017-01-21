using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnnemyState
{
    private readonly StatePatternEnnemy enemy;

    public ChaseState(StatePatternEnnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        Chase();
        if(IsNear)
        {
            ToDemandState();
        }

    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToPatrolState()
    {
        enemy.currentState = enemy.patrolState;
    }

    public void ToChaseState()
    {
        Debug.Log("can't transition to chase from chase");
    }

    public void ToPornLoadState()
    {

    }

    public void ToDemandState()
    {
        enemy.currentState = enemy.demandState;

    }

    public void ToWaitForStuffState()
    {

    }

    private void Chase()
    {
        enemy.navMeshAgent.destination = enemy.chaseTarget.position;
        enemy.navMeshAgent.Resume();
    }

    bool IsNear
    {
        get
        {
            Vector3 diff = enemy.transform.position - enemy.chaseTarget.position;
            diff.y = 0f;
            return diff.magnitude <= 0.5;
        }
    }
}
