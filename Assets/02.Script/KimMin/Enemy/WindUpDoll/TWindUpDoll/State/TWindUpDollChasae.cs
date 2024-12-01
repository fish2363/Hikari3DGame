using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TWindUpDollChase : EnemyState<EnemyStatEnum>
{
    private TWindUpDoll _windUpDoll;
    private float _currrentTime;

    public TWindUpDollChase(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as TWindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();
        _currrentTime = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        ChaseTarget();

        if (_windUpDoll._distance > _windUpDoll.EnemyStat.AttackRadius)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Skill);

        }
    }

    private void ChaseTarget()
    {
        Vector3 moveDir = (_windUpDoll.player.transform.position - _windUpDoll.transform.position).normalized;
        moveDir.y = 0;

        _windUpDoll.RigidCompo.velocity = moveDir * _enemy.EnemyStat.MoveSpeed * 2;
    }
}