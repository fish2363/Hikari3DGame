using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilderChase : EnemyState<EnemyStatEnum>
{
    private Rigidbody _rbCompo;

    private Soilder _soilder;
    public SoilderChase(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _soilder = enemy as Soilder;
    }

    public override void Enter()
    {
        _rbCompo = _enemy.GetComponent<Rigidbody>();
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();


        Vector3 direction = _enemy.player.transform.position - _enemy.transform.position;

        direction.y = 0;


        if (direction.sqrMagnitude > 0.001f)
        {
            direction.Normalize();

            Quaternion lookRotation = Quaternion.LookRotation(direction);

            _enemy.transform.rotation = lookRotation;
        }

        _enemy.range = Vector3.Distance(_enemy.player.transform.position, _enemy.transform.position);

        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _enemy.player.transform.position, _enemy.EnemyStat.MoveSpeed * Time.deltaTime);


        if(_enemy.range <= _soilder.EnemyStat.AttackRadius && _soilder._isAttack)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Attack);
        }

        if (_enemy.hp <= 0)
            _stateMachine.ChangeState(EnemyStatEnum.Dead);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
