using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForStuffState : IEnnemyState
{

    private readonly StatePatternEnnemy enemy;
    private int nextWayPoint;
    float timer = 10;


    public WaitForStuffState(StatePatternEnnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = 10;
            Jauge.Mecontentement.Add(10f);
            enemy.SetDisplayNoActivity();
            GameObject.FindGameObjectWithTag("StudentManager").GetComponent<StudentManager>().RemoveDemandStudent(enemy.gameObject);
            enemy.setNeedAnton(false);
            ToPatrolState();
        }
        WaitForStuff();
        if (IsNear && enemy.player.GetComponent<CharacterMovement>().hasEquipment )
        {
            timer = 10;
            Jauge.Mecontentement.Add(-10f);
            Jauge.Flemme.Add(10f);
            enemy.SetDisplayNoActivity();
            GameObject.FindGameObjectWithTag("StudentManager").GetComponent<StudentManager>().RemoveDemandStudent(enemy.gameObject);
            enemy.setNeedAnton(false);
            enemy.player.GetComponent<CharacterMovement>().hasEquipment = false;
            ToPatrolState();
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

    }

    private void WaitForStuff()
    {
        enemy.navMeshAgent.destination = enemy.studentComputer.position;
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
