﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnnemyState
{

    private readonly StatePatternEnnemy enemy;
    private int nextWayPoint;

    public PatrolState (StatePatternEnnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        Patrol();
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && enemy.GetNeedAnton())
        {
            enemy.chaseTarget = other.transform;
            ToChaseState();
        }
    }
    
    public void ToPatrolState()
    {
        Debug.Log("can't transition to patrol from patrol");
    }
    
    public void ToChaseState()
    {
        enemy.currentState = enemy.chaseState;
    }

    public void ToPornLoadState()
    {
        enemy.currentState = enemy.pornLoadState;
        enemy.SetDisplayPornLoad(true);
        // on baisse le debit ICI
    }

    public void ToDemandState()
    {

    }

    void Patrol()
    {
        enemy.navMeshAgent.destination = enemy.wayPoints[nextWayPoint].position;
        enemy.navMeshAgent.Resume();

        if(enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending)
        {
            nextWayPoint = (nextWayPoint + 1) % enemy.wayPoints.Length;
        }
    }
}
