using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TWindUpDoll : WindUpDoll
{

    protected override void Awake()
    {
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Walk, new TWindUpDollMove(this, stateMachine, "Walk"));
        stateMachine.AddState(EnemyStatEnum.Chase, new TWindUpDollChase(this, stateMachine, "Chase"));
        stateMachine.AddState(EnemyStatEnum.Attack, new TWindUpDollAttack(this, stateMachine, "Attack"));

        stateMachine.InitInitialize(EnemyStatEnum.Walk, this);
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
