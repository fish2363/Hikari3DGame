using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcCarMove : EnemyState<EnemyStatEnum>
{
    public RcCarMove(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        _enemy.MoveCompo.playerPos = GameObject.Find("Player").transform;

        _enemy.MoveCompo.CanMove(10);
    }

    public override void Exit()
    {
        base.Exit();
    }

}
