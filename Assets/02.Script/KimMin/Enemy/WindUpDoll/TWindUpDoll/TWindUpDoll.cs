using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TWindUpDoll : WindUpDoll
{

    protected override void Awake()
    {
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Idle, new NWindUpDollIdle(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyStatEnum.Walk, new NWindUpDollMove(this, stateMachine, "Walk"));
        stateMachine.AddState(EnemyStatEnum.Attack, new NWindUpDollAttack(this, stateMachine, "Attack"));

        stateMachine.InitInitialize(EnemyStatEnum.Idle, this);
    }

    protected override void Update()
    {
        base.Update();
        Debug.Log(stateMachine.CurrentState);
        stateMachine.CurrentState.UpdateState();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, EnemyStat.AttackRadius);
    }
}
