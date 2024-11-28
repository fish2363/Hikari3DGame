using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OttugiChildSkill : EnemyState<EnemyStatEnum>
{
    private OttugiChild _ottugi;
    public OttugiChildSkill(Enemy enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {

        _ottugi = _enemy.GetComponent<OttugiChild>();
        _ottugi.Skill();
    }

    public override void Exit()
    {
        base.Exit();
    }

}
