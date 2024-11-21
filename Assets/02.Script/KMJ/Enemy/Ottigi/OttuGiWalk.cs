using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OttuGiWalk : EnemyState<EnemyStatEnum>
{
    private OttuGi _ottugi;
    public OttuGiWalk(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }


    public override void Enter()
    {
        base.Enter();
        _ottugi = _enemy.GetComponent<OttuGi>();
        Debug.Log("나도 왔다");
        base.Enter();
    }

    public override void UpdateState()
    {
        _enemy.MoveCompo.playerPos = GameObject.FindWithTag("Player").transform;

        _enemy.MoveCompo.CanMove(_enemy._enemyStat.MoveSpeed);

        _enemy.range = Vector3.Distance(_enemy.MoveCompo.playerPos.position, _enemy.transform.position);


        if (_enemy.hp <= 0)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Skill);
        }

        if (_enemy.range <= _enemy._enemyStat.AttackRadius && _ottugi._isSkillExit)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Attack);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
