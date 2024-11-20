using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWindUpDollIdle : EnemyState<EnemyStatEnum>
{
    private WindUpDoll _windUpDoll;

    public NWindUpDollIdle(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as WindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_windUpDoll._distance < _windUpDoll.detectRadius)
        {
            _enemy.stateMachine.ChangeState(EnemyStatEnum.Walk);
        }
    }
}
