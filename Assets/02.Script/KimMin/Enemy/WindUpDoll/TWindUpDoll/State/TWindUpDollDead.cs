using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TWindUpDollDead : EnemyState<EnemyStatEnum>
{
    private TWindUpDoll _windUpDoll;

    public TWindUpDollDead(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as TWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();

        GameObject.Destroy(_windUpDoll.gameObject);
    }
}
