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
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ToChaseState();
        }
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
        enemy.currentState = enemy.pornLoadState;
        // on baisse le debit ICI
    }

    private void Chase()
    {
        enemy.navMeshAgent.destination = enemy.chaseTarget.position;
        enemy.navMeshAgent.Resume();
    }
}
