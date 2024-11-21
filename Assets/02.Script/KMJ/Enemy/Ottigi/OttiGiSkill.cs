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

        _ottugi = _enemy.GetComponent<OttuGi>();
        _ottugi.Skill();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
