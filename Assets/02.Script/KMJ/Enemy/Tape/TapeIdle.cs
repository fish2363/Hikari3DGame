using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeIdle : EnemyState<EnemyStatEnum>
{
    public TapeIdle(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        if (_enemy.MoveCompo.isMove)
            _stateMachine.ChangeState(EnemyStatEnum.Walk);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
