using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindUpDoll : Enemy
{
    [HideInInspector] public float _distance;

    private void Update()
    {
        _distance = (player.transform.position - transform.position).magnitude;
        Debug.Log(stateMachine.CurrentState);

        stateMachine.CurrentState.UpdateState();
    }
}
