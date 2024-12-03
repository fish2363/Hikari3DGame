using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttack : EnemyState<EnemyStatEnum>
{
    public SpiderAttack(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }
}
