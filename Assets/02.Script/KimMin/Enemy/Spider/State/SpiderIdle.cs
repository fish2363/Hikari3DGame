using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderIdle : EnemyState<EnemyStatEnum>
{
    private Spider _spider;

    public SpiderIdle(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _spider = enemy as Spider;
    }

    public override void Enter()
    {
        base.Enter();
        _spider.StopImmediately();
    }
}
