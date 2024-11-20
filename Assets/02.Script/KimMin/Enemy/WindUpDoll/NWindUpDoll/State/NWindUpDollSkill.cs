using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWindUpDollSkill : EnemyState<EnemyStatEnum>
{
    public NWindUpDollSkill(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();

    }
}
