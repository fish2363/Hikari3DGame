using Ami.BroAudio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TWindUpDollMove : EnemyState<EnemyStatEnum>
{
    private TWindUpDoll _windUpDoll;
    private Vector3 _nextPos;

    public TWindUpDollMove(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as TWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();

        _nextPos = _windUpDoll.GetNextPos();
        //BroAudio.Play(_windUpDoll.WindUp);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _windUpDoll.FlipEnemy();
        MoveNextPos();

        if (_windUpDoll._distance < _windUpDoll.detectRadius)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Chase);
        }
    }

    public override void Exit()
    {
        base.Exit();
        //BroAudio.Pause(_windUpDoll.WindUp);
    }

    private void MoveNextPos()
    {
        Vector3 dir = (_nextPos - _windUpDoll.transform.position).normalized;

        if ((_nextPos - _windUpDoll.transform.position).magnitude <= 2f)
        {
            _windUpDoll.MoveCompo.StopImmediately();
            _nextPos = _windUpDoll.GetNextPos();
        }

        _windUpDoll.RigidCompo.velocity = dir * _windUpDoll.EnemyStat.ProwlSpeed;
    }
}
