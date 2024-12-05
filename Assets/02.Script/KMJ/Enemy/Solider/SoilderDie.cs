using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilderDie : EnemyState<EnemyStatEnum>
{
    public SoilderDie(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.gameObject.SetActive(false);
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
