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

        Debug.Log("³ª µé¾î¿È");

        _player = GameObject.FindWithTag("Player");

        base.Enter();

        rcCar.Attack();
    }

    public override void UpdateState()
    {
        
        if(rcCar._isMove)
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
