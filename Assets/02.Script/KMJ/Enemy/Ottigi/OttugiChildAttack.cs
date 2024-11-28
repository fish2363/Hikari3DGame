using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OttugiChildAttack : EnemyState<EnemyStatEnum>
{
    private OttugiChild _ottugi;
    public OttugiChildAttack(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        _ottugi = _enemy.GetComponent<OttugiChild>();
        base.Enter();

        _ottugi.Attack();
    }

    public override void UpdateState()
    {
        if (_ottugi._isSkillExit)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Walk);

        }

        if (_enemy.hp <= 0)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Skill);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}
