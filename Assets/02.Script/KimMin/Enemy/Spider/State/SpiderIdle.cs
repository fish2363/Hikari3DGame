using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderIdle : EnemyState<EnemyStatEnum>
{
    public SpiderIdle(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }
}
