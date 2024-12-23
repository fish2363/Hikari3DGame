using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWindUpDollIdle : EnemyState<EnemyStatEnum>
{
    private NWindUpDoll _windUpDoll;

    public NWindUpDollIdle(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as NWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();
        _windUpDoll.MoveCompo.StopImmediately(_windUpDoll);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_windUpDoll._distance < _windUpDoll.detectRadius)
        {
           _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Walk);
        }
    }
}
