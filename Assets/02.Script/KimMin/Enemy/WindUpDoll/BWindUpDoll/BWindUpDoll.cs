using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWindUpDoll : WindUpDoll
{
    public float moveRadius = 15f;
    public Vector3 startPos;

    protected override void Awake()
    {
        base.Awake();
        stateMachine.AddState(EnemyStatEnum.Walk, new BWindUpDollMove(this, stateMachine, "Move"));
        stateMachine.AddState(EnemyStatEnum.Attack, new BWindUpDollAttack(this, stateMachine, "Attack"));

        stateMachine.InitInitialize(EnemyStatEnum.Walk, this);
        transform.position = startPos;
    }

    protected override void Update()
    {
        base.Update();
        Debug.Log(stateMachine.CurrentState);
        stateMachine.CurrentState.UpdateState();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _enemyStat.AttackRadius);
    }
}
