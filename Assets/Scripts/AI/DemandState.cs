using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemandState : IEnnemyState
{

    private readonly StatePatternEnnemy enemy;
    private int nextWayPoint;

    public DemandState(StatePatternEnnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        

        if(Input.GetKey(KeyCode.Y))
        {
            ToWaitForStuffState();
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
