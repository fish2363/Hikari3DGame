using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcCarMove : EnemyState<EnemyStatEnum>
{
    private RcCar rcCar;
    int randomInteger;
    public RcCarMove(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        rcCar = _enemy.GetComponent<RcCar>();
        Debug.Log("나도 왔다");
        base.Enter();
    }

    public override void UpdateState()
    {

        _enemy.range = Vector3.Distance(_enemy.MoveCompo.playerPos.position, _enemy.transform.position);


        if(_enemy.range <= _enemy.EnemyStat.ContactAttackRadius && rcCar._isSkill)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Skill);
        }

        if (_enemy.range <= _enemy.EnemyStat.AttackRadius)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Attack);
        }


        if (_enemy.hp <= 0)
            _stateMachine.ChangeState(EnemyStatEnum.Dead);
    }

    public override void Exit()
    {
        
    }

}
