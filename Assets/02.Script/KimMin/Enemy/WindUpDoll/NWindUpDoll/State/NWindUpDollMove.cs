using Ami.BroAudio;
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

    public override void Enter()
    {
        base.Enter();
        //BroAudio.Play(_windUpDoll.WindUp);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _windUpDoll.FlipEnemy();

        if (_windUpDoll._distance < 4)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Idle);
        }

        if (_windUpDoll._distance <  _windUpDoll.EnemyStat.AttackRadius && _windUpDoll.canAttack)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Attack);
        }
        if (_windUpDoll._distance > _windUpDoll.detectRadius)
        {
            _windUpDoll.stateMachine.ChangeState(EnemyStatEnum.Idle);
        }

        Move();
    }

    public override void Exit()
    {
        base.Exit();
        //BroAudio.Pause(_windUpDoll.WindUp);
    }

    private void Move()
    {
        Vector3 moveDir = (_windUpDoll.player.transform.position - _windUpDoll.transform.position).normalized;
        moveDir.y = 0;


        _windUpDoll.RigidCompo.velocity = moveDir * _enemy.EnemyStat.ProwlSpeed;
    }
}
