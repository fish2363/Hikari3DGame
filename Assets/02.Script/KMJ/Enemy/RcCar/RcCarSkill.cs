using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcCarSkill : EnemyState<EnemyStatEnum>
{
    public RcCarSkill(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

}
