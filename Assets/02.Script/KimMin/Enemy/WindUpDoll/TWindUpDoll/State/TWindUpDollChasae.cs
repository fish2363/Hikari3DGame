using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TWindUpDollChase : EnemyState<EnemyStatEnum>
{
    private TWindUpDoll _windUpDoll;

    public TWindUpDollChase(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as TWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        ChaseTarget();
        CheckSight();

        if (_windUpDoll.isCollision)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Attack);
        }

        if (_windUpDoll._distance > _windUpDoll.EnemyStat.AttackRadius * 2)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Walk);
        }
    }

    private void ChaseTarget()
    {
        Vector3 moveDir = (_windUpDoll.player.transform.position - _windUpDoll.transform.position).normalized;
        moveDir.y = 0;

        _windUpDoll.RigidCompo.velocity = moveDir * _enemy.EnemyStat.MoveSpeed * 2.5f;
    }

    private void CheckSight()
    {
        if (_windUpDoll.player == null) return;

        _windUpDoll.interV = _windUpDoll.player.transform.position - _windUpDoll.transform.position;

        if (_windUpDoll.interV.magnitude <= _windUpDoll.radius)
        {
            float dot = Vector3.Dot(_windUpDoll.interV.normalized, _windUpDoll.transform.forward);
            float theta = Mathf.Acos(dot);
            float degree = Mathf.Rad2Deg * theta;

            _windUpDoll.isCollision = degree <= _windUpDoll.angleRange / 2f ? true : false;
        }
    }
}