using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAdminState
{
    void UpdateState();

    void OnTriggerEnter(Collider other);

    void ToWanderState();

    void ToTalkingState();

}
