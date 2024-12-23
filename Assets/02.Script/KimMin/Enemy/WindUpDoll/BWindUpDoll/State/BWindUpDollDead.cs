using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWindUpDollDead : EnemyState<EnemyStatEnum>
{
    private BWindUpDoll _windUpDoll;

    public BWindUpDollDead(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as BWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();
        GameObject.Destroy(_windUpDoll.gameObject);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
