using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OttuGiIdle : EnemyState<EnemyStatEnum>
{
    public OttuGiIdle(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void UpdateState()
    {
        if (_enemy.MoveCompo.isMove)
            _stateMachine.ChangeState(EnemyStatEnum.Walk);

        if (_enemy.hp <= 0)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Skill);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}
