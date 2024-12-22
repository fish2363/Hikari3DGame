using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWindUpDollMove : EnemyState<EnemyStatEnum>
{
    private NWindUpDoll _windUpDoll;

    public NWindUpDollMove(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as NWindUpDoll;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        Move();

        if(_windUpDoll._distance <  _windUpDoll.EnemyStat.AttackRadius && _windUpDoll.canAttack)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Attack);
        }
        if (_windUpDoll._distance > _windUpDoll.detectRadius)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Idle);
        }
    }

    private void Move()
    {
        Vector3 moveDir = (_windUpDoll.player.transform.position - _windUpDoll.transform.position).normalized;
        moveDir.y = 0;

        _windUpDoll.RigidCompo.velocity = moveDir * _enemy.EnemyStat.ProwlSpeed * Time.deltaTime;
    }
}
