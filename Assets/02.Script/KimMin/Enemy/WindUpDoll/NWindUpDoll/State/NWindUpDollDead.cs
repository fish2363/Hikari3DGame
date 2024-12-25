using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWindUpDollDead : EnemyState<EnemyStatEnum>
{
    private NWindUpDoll _windUpDoll;

    public NWindUpDollDead(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as NWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();

        GameObject.Destroy(_windUpDoll.gameObject);
    }
}
