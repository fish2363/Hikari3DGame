using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RcCarAttack : EnemyState<EnemyStatEnum>
{
    public RcCarAttack(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }


    public override void Enter()
    {
        Debug.Log("³ª µé¾î¿È");
        base.Enter();
    }

    public override void UpdateState()
    {
        _stateMachine.ChangeState(EnemyStatEnum.Walk);

        if (_enemy.hp <= 0)
            _stateMachine.ChangeState(EnemyStatEnum.Dead);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
