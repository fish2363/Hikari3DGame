using Ami.BroAudio;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BWindUpDollMove : EnemyState<EnemyStatEnum>
{
    private BWindUpDoll _windUpDoll;
    private Vector3 _nextPos;

    public BWindUpDollMove(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as BWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();

        _windUpDoll.StopImmediately();
        _windUpDoll.nextPos = _windUpDoll.GetNextPos();
        BroAudio.Play(_windUpDoll.WindUp);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _windUpDoll.FlipEnemy();
        MoveNextPos();

        if (_windUpDoll._distance <= _windUpDoll.EnemyStat.AttackRadius)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Attack);
        }
    }

    public override void Exit()
    {
        base.Exit();
        BroAudio.Pause(_windUpDoll.WindUp);
    }

    private void MoveNextPos()
    {
        Vector3 dir = (_windUpDoll.nextPos - _windUpDoll.transform.position).normalized;

        if ((_windUpDoll.nextPos - _windUpDoll.transform.position).magnitude <= 2f)
        {
            _windUpDoll.MoveCompo.StopImmediately();
            _windUpDoll.nextPos = _windUpDoll.GetNextPos();
        }

        _windUpDoll.RigidCompo.velocity = dir * _windUpDoll.EnemyStat.ProwlSpeed;
    }
}
