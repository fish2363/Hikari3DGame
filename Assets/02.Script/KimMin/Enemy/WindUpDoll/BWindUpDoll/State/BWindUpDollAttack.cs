using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWindUpDollAttack : EnemyState<EnemyStatEnum>
{
    public BWindUpDollAttack(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
}
