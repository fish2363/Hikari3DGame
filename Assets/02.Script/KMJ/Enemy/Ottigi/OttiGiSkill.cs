using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OttiGiSkill : EnemyState<EnemyStatEnum>
{
    private OttuGi _ottugi;
   

    public OttiGiSkill(EnemyAgent enemy, StateMachine<EnemyStatEnum> state, string animHashName) : base(enemy, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _ottugi = _enemy.GetComponent<OttuGi>();
        _ottugi.Skill();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

}
