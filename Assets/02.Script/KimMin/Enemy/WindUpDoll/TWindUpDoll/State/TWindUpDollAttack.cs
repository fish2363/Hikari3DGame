using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TWindUpDollAttack : EnemyState<EnemyStatEnum>
{
    private TWindUpDoll _windUpDoll;

    public TWindUpDollAttack(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as TWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Attack");
    }

    public override void UpdateState()
    {
        base.UpdateState();

    }
}