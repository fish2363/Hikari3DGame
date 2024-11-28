using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TWindUpDollAttack : EnemyState<EnemyStatEnum>
{
    private TWindUpDoll _windUpDoll;
    private float _currrentTime;

    public TWindUpDollAttack(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as TWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();
        _currrentTime = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();

    }
}