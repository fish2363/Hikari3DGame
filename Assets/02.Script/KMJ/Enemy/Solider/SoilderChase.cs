using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoilderChase : EnemyState<EnemyStatEnum>
{
    private Rigidbody _rbCompo;

    private Soilder _soilder;

    private SoilderObject[] soilderObject;
    public SoilderChase(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _soilder = enemy as Soilder;
    }

    public override void Enter()
    {
        soilderObject = _enemy.GetComponentsInChildren<SoilderObject>();
        _rbCompo = _enemy.GetComponent<Rigidbody>();
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();


        soilderObject.ToList().ForEach(t => t.LookPlayer());

        _enemy.range = Vector3.Distance(_enemy.player.transform.position, _enemy.transform.position);

        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _enemy.player.transform.position, _enemy.EnemyStat.ChasingSpeed * Time.deltaTime);


        if (_enemy.range <= _soilder.EnemyStat.AttackRadius && _soilder._isAttack)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Attack);
        }

        if (_enemy.Hp <= 0)
            _stateMachine.ChangeState(EnemyStatEnum.Dead);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
