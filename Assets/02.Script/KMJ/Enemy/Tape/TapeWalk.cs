using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeWalk : EnemyState<EnemyStatEnum>
{
    private Tape tape;
    public TapeWalk(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        tape = _enemy.GetComponent<Tape>();
        base.Enter();
    }

    public override void UpdateState()
    {
        _enemy.MoveCompo.playerPos = GameObject.FindWithTag("Player").transform;

        //_enemy.MoveCompo.CanMove(_enemy._enemyStat.MoveSpeed);

        _enemy.range = Vector3.Distance(_enemy.MoveCompo.playerPos.position, _enemy.transform.position);

        //if (_enemy.range <= _enemy._enemyStat.AttackRadius && tape._isAttack)
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
