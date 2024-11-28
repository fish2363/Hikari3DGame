using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeWalk : EnemyState<EnemyStatEnum>
{
    private Tape tape;

    public TapeWalk(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        tape = _enemy.GetComponent<Tape>();
        base.Enter();
    }

    public override void UpdateState()
    {
        
        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _enemy.player.transform.position, _enemy.EnemyStat.MoveSpeed * Time.deltaTime);

        _enemy.range = Vector3.Distance(_enemy.player.transform.position, _enemy.transform.position);

        if (_enemy.range <= _enemy.EnemyStat.AttackRadius && tape._isAttack)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Attack);
        }

        if(_enemy.hp <= 0)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Dead);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}
