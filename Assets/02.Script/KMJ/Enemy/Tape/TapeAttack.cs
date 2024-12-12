using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeAttack : EnemyState<EnemyStatEnum>
{
    private Tape _tape;

    public TapeAttack(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        enemy = _tape;
    }

    public override void Enter()
    {
        _tape = _enemy.GetComponent<Tape>();
        _tape.Attack();
        Debug.Log("안온거 맞지?");
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
