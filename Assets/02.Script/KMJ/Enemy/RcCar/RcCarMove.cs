using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcCarMove : EnemyState<EnemyStatEnum>
{
    private RcCar rcCar;
    int randomInteger;

    public RcCarMove(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
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

        _enemy.range = Vector3.Distance(_enemy.player.transform.position, _enemy.transform.position);

     


        if(_enemy.range <= 1)
        {
            _enemy.RigidCompo.velocity = Vector3.zero;
        }
        else
        {
            _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _enemy.player.transform.position, _enemy.EnemyStat.MoveSpeed * Time.deltaTime);
        }
       // _enemy.transform.LookAt(_enemy.transform);

        Vector3 direction = _enemy.player.transform.position - _enemy.transform.position;

        direction.y = 0;


        if (direction.sqrMagnitude > 0.001f)
        {
            direction.Normalize();

            Quaternion lookRotation = Quaternion.LookRotation(direction);

            _enemy.transform.rotation = lookRotation;
        }

        if (_enemy.range <= _enemy.EnemyStat.ContactAttackRadius && rcCar._isSkill)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Skill);
        }
        else if (_enemy.range <= _enemy.EnemyStat.AttackRadius && rcCar._isAttack)
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
