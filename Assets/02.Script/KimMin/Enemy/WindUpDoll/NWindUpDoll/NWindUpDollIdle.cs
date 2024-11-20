using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWindUpDollIdle : EnemyState<EnemyStatEnum>
{
    public NWindUpDollIdle(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void UpdateState()
    {
        base.UpdateState();


    }

    public override void Exit()
    {
        base.Exit();

    }
}
