using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcCarIdle : EnemyState<EnemyStatEnum>
{
    public RcCarIdle(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }
}
