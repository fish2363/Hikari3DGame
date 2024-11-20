using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWindUpDollDead : EnemyState<EnemyStatEnum>
{
    private WindUpDoll _windUpDoll;

    public NWindUpDollDead(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as WindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();
    }
}
