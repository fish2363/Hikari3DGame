using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMove : EnemyState<EnemyStatEnum>
{
    private Spider _spider;

    public SpiderMove(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
        _spider = enemy as Spider;
    }
}
