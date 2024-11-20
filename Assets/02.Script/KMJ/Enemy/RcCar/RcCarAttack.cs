using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RcCarAttack : EnemyState<EnemyStatEnum>
{
    RcCar rcCar;
    public RcCarAttack(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }


    public override void Enter()
    {
        rcCar = _enemy.GetComponent<RcCar>();
        Debug.Log("�� ����");
        base.Enter();

        rcCar.Attack();
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
