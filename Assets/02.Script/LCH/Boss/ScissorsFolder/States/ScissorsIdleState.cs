using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsIdleState : EnemyState<BossState>
{
    public ScissorsIdleState(Enemy enemy, StateMachine<BossState> state, string animHashName) : base(enemy, state, animHashName)
    {
    }
}
