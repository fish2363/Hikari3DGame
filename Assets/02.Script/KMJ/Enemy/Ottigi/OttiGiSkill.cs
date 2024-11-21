using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OttiGiSkill : EnemyState<EnemyStatEnum>
{
    private OttuGi _ottugi;
    public OttiGiSkill(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        _ottugi.Skill();
    }
}
