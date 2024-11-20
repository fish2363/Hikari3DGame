using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OttuGiWalk : EnemyState<EnemyStatEnum>
{
    public OttuGiWalk(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }


    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        
    }
}
