using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcCarSkill : EnemyState<EnemyStatEnum>
{
    private GameObject _player;
    private RcCar _rcCar;

    

    public RcCarSkill(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _rcCar = _enemy.GetComponent<RcCar>();
        _rcCar._isLook = false;

        _rcCar.DashSkill();

        _player = GameObject.FindWithTag("Player");
    }

    public override void UpdateState()
    {

        if(_rcCar._isMove)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Walk);
        }

        if (_enemy.Hp <= 0)
            _stateMachine.ChangeState(EnemyStatEnum.Dead);
    }

    public override void Exit()
    {
        base.Exit();
    }

}
