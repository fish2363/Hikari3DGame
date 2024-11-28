using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RcCarAttack : EnemyState<EnemyStatEnum>
{
    private GameObject _player;
    RcCar rcCar;

    public RcCarAttack(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        rcCar = _enemy.GetComponent<RcCar>();

        Debug.Log("�� ����");

        _player = GameObject.FindWithTag("Player");

        base.Enter();

        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _enemy.player.transform.position, _enemy.EnemyStat.AttackPoawer * Time.deltaTime);

        rcCar.Attack();

        bool ishit = Physics.Raycast(_enemy.transform.position, _enemy.transform.forward, 1, _enemy.whatIsPlayer);

        if (ishit == true)
        {
            Debug.Log("ü�±���");
        }
    }

    public override void UpdateState()
    {
        
        if(rcCar._isAttackExit)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Walk);

            if (_enemy.hp <= 0)
                _stateMachine.ChangeState(EnemyStatEnum.Dead);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
