using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSkill : EnemyState<EnemyStatEnum>
{
    public SpiderSkill(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }
}
