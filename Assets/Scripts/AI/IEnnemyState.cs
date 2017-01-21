using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnnemyState
{
    void UpdateState();

    void OnTriggerEnter(Collider other);

    void ToPatrolState();

    void ToPornLoadState();

    void ToChaseState();

    void ToDemandState();

}
