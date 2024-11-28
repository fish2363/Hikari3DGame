using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeAttack : EnemyState<EnemyStatEnum>
{
    private Tape _tape;
    public TapeAttack(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        _tape.Attack();
    }

    public override void UpdateState()
    {
        if(_tape._isTrueMove)
        {
            _stateMachine.ChangeState(EnemyStatEnum.Walk);
        }
        if (_enemy.hp <= 0)
            _stateMachine.ChangeState(EnemyStatEnum.Dead);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
