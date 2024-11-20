using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWindUpDollMove : EnemyState<EnemyStatEnum>
{
    private WindUpDoll _windUpDoll;

    public NWindUpDollMove(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as WindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();


    }

    private void Move()
    {
        Vector2 moveDir = (_windUpDoll.transform.position - _windUpDoll.transform.position).normalized;

        _windUpDoll.RIgidCompo.velocity = moveDir;
    }
}
