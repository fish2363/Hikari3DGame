using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilderIdle : EnemyState<EnemyStatEnum>
{
    private Vector3 _nextPos;
    private Soilder _soilder;
    public SoilderIdle(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _soilder = enemy as Soilder;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        MoveNextPos();

        if (_soilder._isMove)
            _stateMachine.ChangeState(EnemyStatEnum.Walk);

        if (_soilder.hp <= 0)
            _stateMachine.ChangeState(EnemyStatEnum.Dead);
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void MoveNextPos()
    {
        Vector3 dir = (_nextPos - _soilder.transform.position).normalized;

        if ((_nextPos - _soilder.transform.position).magnitude <= 2f)
        {
            _soilder.MoveCompo.StopImmediately();
            _nextPos = _soilder.GetNextPos();
        }

        _soilder.RigidCompo.velocity = dir * _soilder.EnemyStat.MoveSpeed;
    }
}
