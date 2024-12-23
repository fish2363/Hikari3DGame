using Ami.BroAudio;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TWindUpDollAttack : EnemyState<EnemyStatEnum>
{
    private TWindUpDoll _windUpDoll;

    public TWindUpDollAttack(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as TWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();
        _windUpDoll.isCollision = true;
        BroAudio.Play(_windUpDoll.WindUp);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_windUpDoll._distance > _windUpDoll.EnemyStat.AttackRadius)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Walk);
        }
    }

    public override void Exit()
    {
        base.Exit();
        _windUpDoll.isCollision = false;
        BroAudio.Pause(_windUpDoll.WindUp);
    }
}