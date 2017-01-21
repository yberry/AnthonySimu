using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PornLoadState : IEnnemyState
{

    private readonly StatePatternEnnemy enemy;
    private int nextWayPoint;

    public PornLoadState(StatePatternEnnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        PornLoad();
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
        Debug.Log("can't transition to pornload from pornload");
    }

    private void PornLoad()
    {
        enemy.navMeshAgent.destination = enemy.studentComputer.position;
        enemy.navMeshAgent.Resume();
    }

}
