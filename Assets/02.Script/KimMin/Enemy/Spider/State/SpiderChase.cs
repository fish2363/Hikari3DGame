using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderChase : EnemyState<EnemyStatEnum>
{
    private Spider _spider;

    public SpiderChase(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _spider = enemy as Spider;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        ChaseTarget();

        if ((_spider.player.transform.position - _spider.transform.position).magnitude
            > _spider.EnemyStat.AttackRadius)
        {
            _spider.stateMachine.ChangeState(EnemyStatEnum.Attack);
        }
    }

    private void ChaseTarget()
    {
        Vector3 moveDir = (_spider.player.transform.position - _spider.transform.position).normalized;
        moveDir.y = 0;

        _spider.RigidCompo.velocity = moveDir * _enemy.EnemyStat.MoveSpeed * 2;
    }
}
