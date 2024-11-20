using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWindUpDollMove : EnemyState<EnemyStatEnum>
{
    private WindUpDoll _windUpDoll;

    public NWindUpDollMove(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _windUpDoll = enemy as WindUpDoll;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        Move();

        if(_windUpDoll._distance <  _windUpDoll._enemyStat.AttackRadius)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Idle);
        }
    }

    private void Move()
    {
        Vector3 moveDir = (_windUpDoll.transform.position - _windUpDoll.transform.position).normalized;
        moveDir.y = 0;

        _windUpDoll.RIgidCompo.velocity = moveDir * _enemy._enemyStat.MoveSpeed;
    }
}
