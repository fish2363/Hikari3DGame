using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindUpDoll : Enemy
{
    public float detectRadius = 4.0f;
    [HideInInspector] public float _distance;

    protected override void Awake()
    {
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Idle, new NWindUpDollIdle(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyStatEnum.Walk, new NWindUpDollMove(this, stateMachine, "Walk"));

        stateMachine.InitInitialize(EnemyStatEnum.Idle, this);
    }

    private void Update()
    {
        _distance = (player.transform.position - transform.position).magnitude;
        Debug.Log(stateMachine.CurrentState);

        stateMachine.CurrentState.UpdateState();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
