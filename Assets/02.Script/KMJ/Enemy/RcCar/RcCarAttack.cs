using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcCarAttack : EnemyState<EnemyStatEnum>
{
    public RcCarAttack(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

}
