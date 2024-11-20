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

        float distance = (_windUpDoll.player.transform.position 
            - _windUpDoll.transform.position).magnitude;

        if (distance < _windUpDoll.detectRadius)
        {
            _enemy.stateMachine.ChangeState(EnemyStatEnum.Walk);
        }
    }
}
