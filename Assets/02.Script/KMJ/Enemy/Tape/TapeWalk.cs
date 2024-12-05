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
        Vector3 direction = _enemy.player.transform.position - _enemy.transform.position;

        direction.y = 0;


        if (direction.sqrMagnitude > 0.001f)
        {
            direction.Normalize();

            Quaternion lookRotation = Quaternion.LookRotation(direction);

            _enemy.transform.rotation = lookRotation;
        }

        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _enemy.player.transform.position, _enemy.EnemyStat.ProwlSpeed * Time.deltaTime);

        _enemy.range = Vector3.Distance(_enemy.player.transform.position, _enemy.transform.position);

        if (_enemy.range <= _enemy.EnemyStat.AttackRadius && tape._isAttack)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Attack);
        }

        if(_enemy.Hp <= 0)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Dead);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}
