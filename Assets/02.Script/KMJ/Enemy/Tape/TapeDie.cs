using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeDie : EnemyState<EnemyStatEnum>
{
    public TapeDie(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
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