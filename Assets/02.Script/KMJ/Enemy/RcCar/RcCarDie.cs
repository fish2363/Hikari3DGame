using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcCarDie : EnemyState<EnemyStatEnum>
{
    public RcCarDie(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }
}
