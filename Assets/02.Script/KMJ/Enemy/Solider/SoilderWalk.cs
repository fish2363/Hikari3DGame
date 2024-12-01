using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilderWalk : EnemyState<EnemyStatEnum>
{
    private Rigidbody _rbCompo;

    private Soilder soilder;
    public SoilderWalk(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        soilder = enemy as Soilder;
    }

    public override void Enter()
    {
        _rbCompo = _enemy.GetComponent<Rigidbody>();
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _enemy.range = Vector3.Distance(_enemy.player.transform.position, _enemy.transform.position);

        Debug.Log("ππ¿” §©§∑");


        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _enemy.player.transform.position, _enemy.EnemyStat.MoveSpeed * Time.deltaTime);


        if(_enemy.range <= soilder.EnemyStat.AttackRadius && soilder._isAttack)
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
