using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoilderWalk : EnemyState<EnemyStatEnum>
{
    private Vector3 _nextPos;
    private Soilder _soilder;
    private SoilderObject[] soilderObject;

    public SoilderWalk(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _soilder = enemy as Soilder;
    }

    public override void Enter()
    {
        base.Enter();
        _nextPos = _soilder.GetNextPos();

        soilderObject = _enemy.GetComponentsInChildren<SoilderObject>();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        MoveNextPos();

        _enemy.range = Vector3.Distance(_enemy.player.transform.position, _enemy.transform.position);

        


        soilderObject.ToList().ForEach(t => t.transform.rotation = Quaternion.LookRotation(new Vector3(_enemy.RigidCompo.velocity.x, 0, _enemy.RigidCompo.velocity.z)));

        if (_soilder.MoveCompo.isMove)
            _stateMachine.ChangeState(EnemyStatEnum.Chase);

        if (_soilder.Hp <= 0)
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

        _soilder.RigidCompo.velocity = dir * _soilder.EnemyStat.ProwlSpeed;
    }
}
